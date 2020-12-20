using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace KaiHungHuang.CabsBooking.Core.RepositoryInterface
{
    public interface IAsyncRepository<T> where T: class
    {
        //CRUD operations
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> ListAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int id);
    }
}