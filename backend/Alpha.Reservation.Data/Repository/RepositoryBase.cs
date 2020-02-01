using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Alpha.Reservation.Data.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext _context;
        
        public RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
 
        public IQueryable<T> FindAll()
        {
            return _context.Set<T>().AsNoTracking();
        }
 
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).AsNoTracking();
        }
 
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }
 
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
 
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}