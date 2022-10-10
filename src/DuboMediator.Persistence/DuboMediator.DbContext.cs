using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using DuboMediator.Persistence.Configuration;

namespace DuboMediator.Persistence
{
    public class DuboMediatorDbContext : AuditableDbContext
    {
        public DuboMediatorDbContext(DbContextOptions<DuboMediatorDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Lecture> Lectures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsersConfiguration());
            modelBuilder.ApplyConfiguration(new RolesConfiguration());
            modelBuilder.ApplyConfiguration(new UserRolesConfiguration());
            modelBuilder.ApplyConfiguration(new CoursesConfiguration());
        }
    }
}