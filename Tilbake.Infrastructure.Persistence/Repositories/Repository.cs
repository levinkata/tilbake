using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TilbakeDbContext _context;
        protected DbSet<TEntity> dbSet;

        public Repository(TilbakeDbContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }
        
        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        } 

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRangeAsync(entities);
        }

        public virtual void Delete(Guid id)
        {
            var entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);
            
            return await Task.Run(() => query.AsNoTracking().ToListAsync());
        }
        
        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public virtual async Task<TEntity> GetFirstOrDefaultAsync(
            Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity,
                object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include).AsNoTracking();

            return await query.FirstOrDefaultAsync(filter);
        }

        public virtual void Update(Guid id, TEntity entity)
        {
            var oldEntity = dbSet.FindAsync(id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
        }
    }
}
