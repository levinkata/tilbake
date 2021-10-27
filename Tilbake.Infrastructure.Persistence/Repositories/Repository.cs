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
        
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                dbSet.Add(entity);
                return await Task.FromResult(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }           
        } 

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => dbSet.AddRangeAsync(entities));
            return entities;
        }

        public virtual async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"{nameof(id)} could not be found.");
            }
            await DeleteAsync(entity);
            return entity;
        }

        public virtual async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new Exception($"{nameof(entity)} could not be found.");
            }

            if (_context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            
            await Task.Run(() => dbSet.Remove(entity));
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                throw new Exception($"{nameof(entities)} could not be found.");
            }

            await Task.Run(() => dbSet.RemoveRange(entities));
            return entities;
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

            try
            {
                return await Task.Run(() => query.AsNoTracking().ToListAsync());
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }
        
        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);
                if (entity == null)
                {
                    throw new Exception($"Couldn't find entity with id={id}");
                }

                _context.Entry(entity).State = EntityState.Detached;
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entity with id={id}: {ex.Message}");
            }
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

        public virtual async Task<TEntity> UpdateAsync(Guid id, TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                var oldEntity = await dbSet.FindAsync(id);
                _context.Entry(oldEntity).CurrentValues.SetValues(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
