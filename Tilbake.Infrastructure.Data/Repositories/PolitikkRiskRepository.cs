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
    public class PolitikkRiskRepository : IPolitikkRiskRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PolitikkRiskRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(PolitikkRisk politikkRisk)
        {
            if (politikkRisk == null)
            {
                throw new ArgumentNullException(nameof(politikkRisk));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                politikkRisk.ID = Guid.NewGuid();
                await context.PolitikkRisks.AddAsync((PolitikkRisk)politikkRisk).ConfigureAwait(true);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
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

            PolitikkRisk politikkRisk = await context.PolitikkRisks.FindAsync(id).ConfigureAwait(true);
            context.PolitikkRisks.Remove((PolitikkRisk)politikkRisk);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<PolitikkRisk>> GetAllAsync(Guid politikkId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.PolitikkRisks
                                                .Where(r => r.PolitikkID == politikkId)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<PolitikkRisk> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.PolitikkRisks
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(PolitikkRisk politikkRisk)
        {
            if (politikkRisk == null)
            {
                throw new ArgumentNullException(nameof(politikkRisk));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.PolitikkRisks.Update((PolitikkRisk)politikkRisk);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}