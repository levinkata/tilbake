using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tilbake.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        Task Delete(Guid id);
        void Delete(TEntity entity);
    }
}
