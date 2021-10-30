using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.Core.Constants;

namespace Tilbake.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(Guid id);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> criteria = null, params Expression<Func<TEntity, object>>[] includes);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        TEntity Find(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);
        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> criteria);
        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> criteria,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria);
        Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes);
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity);
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
        TEntity Update(Guid id, TEntity entity);
        void Delete(Guid id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        void Attach(TEntity entity);
        void AttachRange(IEnumerable<TEntity> entities);
        int Count();
        int Count(Expression<Func<TEntity, bool>> criteria);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);

        // Task<IReadOnlyList<TEntity>> GetAllAsync(
        //     Expression<Func<TEntity, bool>> filter = null,
        //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //     params Expression<Func<TEntity, object>>[] includes);
        // Task<TEntity> GetFirstOrDefaultAsync(
        //     Expression<Func<TEntity, bool>> filter = null,
        //     params Expression<Func<TEntity, object>>[] includes);
    }
}
