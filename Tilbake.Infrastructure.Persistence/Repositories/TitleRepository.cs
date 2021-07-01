using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly TilbakeDbContext _context;

        public TitleRepository(TilbakeDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Title> AddAsync(Title title)
        {
            await _context.Titles.AddAsync(title).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return title;
        }

        public async Task<IQueryable<Title>> AddRangeAsync(IQueryable<Title> titles)
        {
            await _context.Titles.AddRangeAsync(titles).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return titles;
        }

        public async Task<Title> DeleteAsync(Guid id)
        {
            Title title = await _context.Titles
                                    .Where(e => e.Id == id)
                                    .FirstOrDefaultAsync().ConfigureAwait(true);            
            if (title == null)
            {
                return title;
            }

            await Task.Run(() => _context.Titles.Remove(title)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return title;
        }

        public async Task<Title> DeleteAsync(Title title)
        {
            if (title == null)
            {
                return title;
            }
            
            await Task.Run(() => _context.Titles.Remove(title)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return title;
        }

        public async Task<IQueryable<Title>> DeleteRangeAsync(IQueryable<Title> titles)
        {
            if (titles == null)
            {
                return titles;
            }

            await Task.Run(() => _context.Titles.RemoveRange(titles)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return titles;
        }

        public async Task<IQueryable<Title>> GetAllAsync()
        {
            IQueryable<Title> titles = _context.Titles.OrderBy(n => n.Name).AsNoTracking();
            return await Task.Run(() => titles).ConfigureAwait(true);
        }

        public async Task<Title> GetByIdAsync(Guid id)
        {
            return await Task.Run(() => _context.Titles
                                                .Where(e => e.Id == id)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<Title> UpdateAsync(Title title)
        {
            if (title == null)
            {
                return title;
            }
            
            await Task.Run(() => _context.Titles.Update(title)).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return title;
        }
    }
}