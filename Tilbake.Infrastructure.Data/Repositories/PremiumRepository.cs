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
    public class PremiumRepository : IPremiumRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PremiumRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }


        public async Task<int> AddAsync(Premium premium)
        {
            if (premium == null)
            {
                throw new ArgumentNullException(nameof(premium));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                premium.ID = Guid.NewGuid();
                await _context.Premiums.AddAsync((Premium)premium).ConfigureAwait(true);
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
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Premium premium = await context.Premiums.FindAsync(id).ConfigureAwait(true);
            context.Premiums.Remove((Premium)premium);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Premium>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Premiums
                                                .Include(k => k.Politikk)
                                                    .ThenInclude(k => k.Insurer)
                                                .Include(i => i.PremiumType)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Premium> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Premiums
                                                .Include(k => k.Politikk)
                                                    .ThenInclude(k => k.Insurer)
                                                .Include(i => i.PremiumType)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Premium premium)
        {
            if (premium == null)
            {
                throw new ArgumentNullException(nameof(premium));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.Premiums.Update((Premium)premium);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
