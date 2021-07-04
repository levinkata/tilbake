using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

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

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
            if (entity == null)
            {
                return entity;
            }

            await Task.Run(() => _context.Set<TEntity>().Remove(entity)).ConfigureAwait(true);
            return entity;
        }

        public async Task<TEntity> Delete(TEntity entity)
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

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await Task.Run(() => _context.Set<TEntity>().AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            await Task.Run(() => _context.Set<TEntity>().Update(entity)).ConfigureAwait(true);
            return entity;
        }
    }
}
