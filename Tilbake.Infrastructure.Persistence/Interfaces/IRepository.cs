using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);

        Task<TEntity> GetByIdAsync(Guid id);

        Task<TEntity> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(Guid id, TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);        
    }
}
