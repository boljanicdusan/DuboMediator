using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DuboMediator.Application.Contracts.Persistence
{
    public interface IRepository<T> : IRepository<T, Guid> where T : class
    {

    }
    
    public interface IRepository<T, IT> where T : class
    {
        Task<T> Get(IT id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Add(T entity);
        Task<bool> Exists(IT id);
        Task Update(T entity);
        Task Delete(T entity);
    }
}