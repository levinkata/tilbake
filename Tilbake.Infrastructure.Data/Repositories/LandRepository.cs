using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class LandRepository : ILandRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public LandRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Land land)
        {
            if (land == null)
            {
                throw new ArgumentNullException(nameof(land));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                land.ID = Guid.NewGuid();
                await _context.Lands.AddAsync((Land)land).ConfigureAwait(true);
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

            Land land = await _context.Lands.FindAsync(id).ConfigureAwait(true);
            _context.Lands.Remove((Land)land);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Land>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Lands
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Land> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Lands
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Land land)
        {
            if (land == null)
            {
                throw new ArgumentNullException(nameof(land));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Lands.Update((Land)land);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
