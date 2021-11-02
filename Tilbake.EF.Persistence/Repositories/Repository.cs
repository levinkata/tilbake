﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

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

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            dbSet.AddRange(entities);
        }

        public virtual void Delete(Guid id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            dbSet.Remove(entityToDelete);
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

        public virtual void Update(Guid id, TEntity entity)
        {
            var oldEntity = dbSet.Find(id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);
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
