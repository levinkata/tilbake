using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task <IEnumerable<TEntity>> AddRangeAsync (IEnumerable<TEntity> entities);        
        Task<TEntity> Update(TEntity entity);
        Task<TEntity> Delete(Guid id);
        Task<TEntity> Delete(TEntity entity);
        Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities);        
    }
}
