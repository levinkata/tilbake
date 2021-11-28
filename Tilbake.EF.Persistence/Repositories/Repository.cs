using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected TilbakeDbContext _context;
        protected DbSet<TEntity> dbSet;

        public Repository(TilbakeDbContext context)
        {
            _context = context;
            dbSet = _context.Set<TEntity>();
        }

        public virtual async Task<bool> Add(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
                return true;
            }
            return false;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll(
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity> GetFirstOrDefault(
            Expression<Func<TEntity, bool>> filter = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(filter);
        }

        public virtual async Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).AsNoTracking().ToListAsync();
            }
            else
            {
                return await query.AsNoTracking().ToListAsync();
            }
        }

        public virtual async Task<bool> Update(TEntity entity)
        {
            dbSet.Update(entity);
            return await Task.FromResult(true);
        }

        //  To replace below
        //  ====================================================================
        public async Task<IReadOnlyList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null,
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

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        //public virtual async Task<TEntity> GetFirstOrDefaultAsync(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = dbSet;

        //    foreach (Expression<Func<TEntity, object>> include in includes)
        //        query = query.Include(include).AsNoTracking();

        //    return await query.FirstOrDefaultAsync(filter);
        //}

        //public virtual void Add(TEntity entity)
        //{
        //    dbSet.Add(entity);
        //}

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            try
            {
                await dbSet.AddAsync(entity);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }           
        }
        
        //public virtual void AddRange(IEnumerable<TEntity> entities)
        //{
        //    dbSet.AddRange(entities);
        //}

        //public virtual void Delete(Guid id)
        //{
        //    TEntity entityToDelete = dbSet.Find(id);
        //    dbSet.Remove(entityToDelete);
        //}

        //public virtual void Delete(TEntity entityToDelete)
        //{
        //    if (_context.Entry(entityToDelete).State == EntityState.Detached)
        //    {
        //        dbSet.Attach(entityToDelete);
        //    }
        //    dbSet.Remove(entityToDelete);
        //}

        //public virtual void DeleteRange(IEnumerable<TEntity> entities)
        //{
        //    dbSet.RemoveRange(entities);
        //}

        public virtual void Update(Guid id, TEntity entity)
        {
            var oldEntity = dbSet.Find(id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
        }
    }
}
