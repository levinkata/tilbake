using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;

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

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().Where(predicate).AsNoTracking();
            return await Task.Run(() => query.ToListAsync()).ConfigureAwait(true);
        } 

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            IQueryable<TEntity> query = _context.Set<TEntity>().AsNoTracking();
            return await Task.Run(() => query.ToListAsync()).ConfigureAwait(true);
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
