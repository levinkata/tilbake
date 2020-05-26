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
    public class KlientRiskRepository : IKlientRiskRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public KlientRiskRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            KlientRisk klientRisk = await context.KlientRisks.FindAsync(id).ConfigureAwait(true);
            context.KlientRisks.Remove((KlientRisk)klientRisk);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<KlientRisk>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.KlientRisks
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.AllRisk)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.Content)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.House)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.Motor)
                                                .Include(a => a.Klient)
                                                .Include(a => a.PolitikkRisks)
                                                .Include(a => a.QuoteItems)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<KlientRisk> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.KlientRisks
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.AllRisk)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.Content)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.House)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.Motor)
                                                .Include(a => a.Klient)
                                                .Include(a => a.PolitikkRisks)
                                                .Include(a => a.QuoteItems)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<KlientRisk>> GetKlientRisks(Guid klientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.KlientRisks
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.AllRisk)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.Content)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.House)
                                                .Include(a => a.Risk)
                                                    .ThenInclude(r => r.Motor)
                                                .Include(a => a.Klient)
                                                .Include(a => a.PolitikkRisks)
                                                .Include(a => a.QuoteItems)
                                                .Where(k => k.KlientID == klientId)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }
    }
}
