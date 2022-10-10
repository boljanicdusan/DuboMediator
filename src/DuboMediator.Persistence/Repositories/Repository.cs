using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DuboMediator.Application.Contracts.Persistence;
using DuboMediator.Domain.EntityBase;
using Microsoft.EntityFrameworkCore;

namespace DuboMediator.Persistence.Repositories
{
    public class Repository<T> : Repository<T, Guid> where T : Entity<Guid>
    {
        public Repository(DuboMediatorDbContext context) : base(context)
        { }

        public override async Task<T> Add(T entity)
        {
            entity.Id = Guid.NewGuid();
            return await base.Add(entity);
        }
    }
    
    public class Repository<T, IT> : IRepository<T, IT> where T : Entity<IT> where IT : IComparable
    {
        private readonly DuboMediatorDbContext _context;

        public Repository(DuboMediatorDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            // entity.Id = Guid.NewGuid();
            await _context.AddAsync(entity);
            return entity;
        }

        public virtual async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual async Task<bool> Exists(IT id)
        {
            return await _context.Set<T>().AnyAsync(e => e.Id.Equals(id));
        }

        public virtual async Task<T> Get(IT id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<IReadOnlyList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}