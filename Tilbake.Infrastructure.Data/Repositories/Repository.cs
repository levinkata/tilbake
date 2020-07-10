using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public Repository(DbContext context) => _context = context;

        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity).ConfigureAwait(true);

        public async Task Delete(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);
            _context.Set<TEntity>().Remove(entity);
        }

        public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => _context.Set<TEntity>().Where(predicate);

        public async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync().ConfigureAwait(true);

        public async Task<TEntity> GetById(Guid id) => await _context.Set<TEntity>().FindAsync(id).ConfigureAwait(true);

        public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);
    }
}
