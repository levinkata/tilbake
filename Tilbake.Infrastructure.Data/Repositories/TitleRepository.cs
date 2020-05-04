using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class TitleRepository : ITitleRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public TitleRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Title title)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                title.ID = Guid.NewGuid();
                await _context.Titles.AddAsync((Title)title).ConfigureAwait(true);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Title title = await _context.Titles.FindAsync(id).ConfigureAwait(true);
            _context.Titles.Remove((Title)title);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Title>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Titles
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Title> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Titles
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Title title)
        {
            if (title == null)
            {
                throw new ArgumentNullException(nameof(title));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Titles.Update((Title)title);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
