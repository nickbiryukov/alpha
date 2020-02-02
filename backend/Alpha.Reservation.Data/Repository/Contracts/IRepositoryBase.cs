using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Alpha.Reservation.Data.Repository.Contracts
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(Guid id);
        
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        
        Task<List<TEntity>> GetAllAsync();
        
        Task<List<TEntity>> GetByPredicateAsync(Expression<Func<TEntity, bool>> predicate);   
        
        Task<TEntity> AddAsync(TEntity entity);
        
        Task<TEntity> UpdateAsync(TEntity entity);
        
        Task DeleteAsync(Guid id);
    }
}