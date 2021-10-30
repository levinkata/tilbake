using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Constants;

namespace Tilbake.EF.Persistence.Repositories
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
        
        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public TEntity GetById(Guid id)
        {
            return dbSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>> criteria = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include).AsNoTracking();

            return await query.FirstOrDefaultAsync(criteria); 
        }        

        public TEntity Find(Expression<Func<TEntity, bool>> criteria = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return query.AsNoTracking().SingleOrDefault(criteria);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> criteria = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.AsNoTracking().SingleOrDefaultAsync(criteria);
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> criteria = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return query.AsNoTracking().Where(criteria).ToList();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> criteria = null)
        {
            return dbSet.AsNoTracking().Where(criteria).ToList();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> criteria = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet.Where(criteria);

            if (criteria != null)
                query = query.Where(criteria);

            if (orderBy != null)
                query = orderBy(query);
            

            return query.AsNoTracking().ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.AsNoTracking().Where(criteria).ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria = null)
        {
            return await dbSet.AsNoTracking().Where(criteria).ToListAsync();
        }
        
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet.Where(criteria);

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public TEntity Add(TEntity entity)
        {
            dbSet.Add(entity);
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await dbSet.AddRangeAsync(entities);
            return entities;
        }

        public TEntity Update(Guid id, TEntity entity)
        {
            var oldEntity = dbSet.FindAsync(id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(Guid id)
        {
            var entity = dbSet.Find(id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            dbSet.RemoveRange(entities);
        }

        public void Attach(TEntity entity)
        {
            dbSet.Attach(entity);
        }

        public void AttachRange(IEnumerable<TEntity> entities)
        {
            dbSet.AttachRange(entities);
        }

        public int Count()
        {
            return dbSet.AsNoTracking().Count();
        }

        public int Count(Expression<Func<TEntity, bool>> criteria)
        {
            return dbSet.AsNoTracking().Count(criteria);
        }

        public async Task<int> CountAsync()
        {
            return await dbSet.AsNoTracking().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria)
        {
            return await dbSet.AsNoTracking().CountAsync(criteria);
        }


        // public async Task<IReadOnlyList<TEntity>> GetAllAsync(
        //     Expression<Func<TEntity, bool>> filter = null,
        //     Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //     params Expression<Func<TEntity, object>>[] includes)
        // {
        //     IQueryable<TEntity> query = dbSet;

        //     foreach (Expression<Func<TEntity, object>> include in includes)
        //         query = query.Include(include);

        //     if (filter != null)
        //         query = query.Where(filter);

        //     if (orderBy != null)
        //         query = orderBy(query);

        //     return await Task.Run(() => query.AsNoTracking().ToListAsync());
        // }



        // public async Task<TEntity> GetFirstOrDefaultAsync(
        //     Expression<Func<TEntity, bool>> filter = null,
        //     params Expression<Func<TEntity,
        //         object>>[] includes)
        // {
        //     IQueryable<TEntity> query = dbSet;

        //     foreach (Expression<Func<TEntity, object>> include in includes)
        //         query = query.Include(include).AsNoTracking();

        //     return await query.FirstOrDefaultAsync(filter);
        // }
    }
}
