using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tilbake.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<TEntity> GetById(Guid id);
        Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        Task<bool> Add(TEntity entity);
        Task<bool> Delete(Guid id);
        Task<bool> Update(TEntity entity);

        //  ===============================================================================
        //  To replace the below
        //  ===============================================================================

        Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes);
        //void Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity); 
        void AddRange(IEnumerable<TEntity> entities);
        //void Delete(Guid id);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Update(Guid id, TEntity entity);
    }
}
