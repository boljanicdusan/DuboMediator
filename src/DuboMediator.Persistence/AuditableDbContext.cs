using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Consts;
using DuboMediator.Domain.Attributes;
using DuboMediator.Domain.Entities;
using DuboMediator.Domain.EntityBase;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace DuboMediator.Persistence
{
    public class AuditableDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AuditableDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ChangeLog> ChangeLogs { get; set; }

        public virtual async Task<int> SaveChangesAsync(string userId = "SYSTEM", CancellationToken token = default)
        {
            await TrackCreating(userId);
            await TrackUpdating(userId);
            await TrackDeleting(userId);
            
            return await base.SaveChangesAsync(token);
        }

        private async Task TrackCreating(string userId)
        {
            var addedEntities = base.ChangeTracker
                .Entries()
                .Where(p => p.State == EntityState.Added)
                .ToList();
            
            foreach (var change in addedEntities)
            {
                var entity = change.Entity as IAuditCreating;
                if (entity != null)
                {
                    entity.CreationTime = DateTime.UtcNow;
                    entity.CreatedByUserId = userId;
                }

                if (change.Entity is Entity)
                {
                    var entityName = change.Entity.GetType().Name;
                    var primaryKey = ((Entity)change.Entity).Id.ToString();

                    //Create the Change Log
                    var changeLog = new ChangeLog
                    {
                        Entity = entityName,
                        EntityId = primaryKey,
                        PropertyName = null,
                        OldValue = null,
                        NewValue = ConvertToJsonString(change),
                        ChangeType = ChangeTypes.Created,
                        ChangeTime = DateTime.UtcNow,
                        ChangedByUserId = userId
                    };
                    await ChangeLogs.AddAsync(changeLog);
                }
            }
        }

        private async Task TrackUpdating(string userId)
        {
            var modifiedEntities = base.ChangeTracker
                .Entries()
                .Where(p => p.State == EntityState.Modified)
                .ToList();

            foreach (var change in modifiedEntities)
            {
                if (IsSoftDeleted(change))
                {
                    var entity = change.Entity as IAuditDeleting;
                    if (entity != null)
                    {
                        entity.DeletionTime = DateTime.UtcNow;
                        entity.DeletedByUserId = userId;
                    }
                }
                else
                {
                    var entity = change.Entity as IAuditUpdating;
                    if (entity != null)
                    {
                        entity.LastModificationTime = DateTime.UtcNow;
                        entity.LastModifiedByUserId = userId;
                    }
                }

                if (change.Entity is Entity)
                {
                    var entityName = change.Entity.GetType().Name;
                    var primaryKey = ((Entity)change.Entity).Id.ToString();

                    foreach(var prop in change.OriginalValues.Properties)
                    {
                        var property = change.Entity.GetType().GetProperty(prop.Name);
                        var ignoreAudit = property.CustomAttributes.Any(ca => ca.AttributeType == typeof(IgnoreAudit));
                        
                        if (!ignoreAudit)
                        {
                            var originalValue = change.OriginalValues[prop]?.ToString();
                            var currentValue = change.CurrentValues[prop]?.ToString();
                            if (originalValue != currentValue) //Only create a log if the value changes
                            {
                                //Create the Change Log
                                var changeLog = new ChangeLog
                                {
                                    Entity = entityName,
                                    EntityId = primaryKey,
                                    PropertyName = prop.Name,
                                    OldValue = originalValue,
                                    NewValue = currentValue,
                                    ChangeType = ChangeTypes.Updated,
                                    ChangeTime = DateTime.UtcNow,
                                    ChangedByUserId = userId
                                };
                                await ChangeLogs.AddAsync(changeLog);
                            }
                        }
                    }
                }
            }
        }

        private async Task TrackDeleting(string userId)
        {
            var deletedEntities = base.ChangeTracker
                .Entries()
                .Where(e => e.State == EntityState.Deleted)
                .ToList();

            foreach (var change in deletedEntities)
            {
                if (change.Entity is Entity)
                {
                    var entityName = change.Entity.GetType().Name;
                    var primaryKey = ((Entity)change.Entity).Id.ToString();

                    // Create the Change Log
                    var changeLog = new ChangeLog
                    {
                        Entity = entityName,
                        EntityId = primaryKey,
                        PropertyName = null,
                        OldValue = null,
                        NewValue = null,
                        ChangeType = ChangeTypes.Deleted,
                        ChangeTime = DateTime.UtcNow,
                        ChangedByUserId = userId
                    };
                    await ChangeLogs.AddAsync(changeLog);
                }
            }
        }

        private bool IsSoftDeleted(EntityEntry change)
        {
            var isDeletedProperty = change.OriginalValues.Properties.FirstOrDefault(p => p.Name == AppConsts.SoftDeletePropertyName);
            return isDeletedProperty != null 
                && change.OriginalValues[isDeletedProperty] != change.CurrentValues[isDeletedProperty]
                && (bool)change.CurrentValues[isDeletedProperty];

        }

        private string ConvertToJsonString(EntityEntry change)
        {
            return JsonConvert.SerializeObject(
                change.Entity,
                Formatting.Indented, 
                new JsonSerializerSettings() 
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
        }
    }
}