﻿using Microsoft.EntityFrameworkCore;
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
        protected readonly TilbakeDbContext _context;
        private DbSet<TEntity> dbSet;

        public Repository(TilbakeDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().AddAsync(entity)).ConfigureAwait(true);
            return entity;            
        } 

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _context.Set<TEntity>().AddRangeAsync(entities)).ConfigureAwait(true);
            return entities;
        }

        public async Task<TEntity> DeleteAsync(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
            if (entity == null)
            {
                return entity;
            }

            await Task.Run(() => _context.Set<TEntity>().Remove(entity)).ConfigureAwait(true);
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            if (entity == null)
            {
                return entity;
            }

            await Task.Run(() => _context.Set<TEntity>().Remove(entity)).ConfigureAwait(true);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
            {
                return entities;
            }

            await Task.Run(() => _context.Set<TEntity>().RemoveRange(entities)).ConfigureAwait(true);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _context.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Task.Run(() => _context.Set<TEntity>().AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await Task.Run(() => query.ToList());
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            foreach (Expression<Func<TEntity, object>> include in includes)
                query = query.Include(include);

            return await query.FirstOrDefaultAsync(filter);
        }

        public async Task<IQueryable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await Task.Run(() => query);
        }

        public async Task<TEntity> UpdateAsync(Guid id, TEntity entity)
        {
            var oldEntity = await _context.Set<TEntity>().FindAsync(id);
            _context.Entry(oldEntity).CurrentValues.SetValues(entity);

            _context.Entry(entity).State = EntityState.Detached;
            _context.Entry(oldEntity).State = EntityState.Modified;

            //await Task.Run(() => _context.Set<TEntity>().Update(entity)).ConfigureAwait(true);
            await Task.Run(() => _context.Set<TEntity>().Update(oldEntity)).ConfigureAwait(true);
            return entity;
        }
    }
}
