using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;
using Tilbake.Infrastructure.Data.Generators;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class KravRepository : IKravRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public KravRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Krav krav)
        {
            if (krav == null)
            {
                throw new ArgumentNullException(nameof(krav));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();
                var kravkNumber = KravNumbers.Get(context);

                await Task.Run(async () =>
                {
                    krav.KravNumber = kravkNumber;
                    await context.Kravs.AddAsync((Krav)krav).ConfigureAwait(true);

                    KravNumberGenerator kravNumberGenerator = new KravNumberGenerator
                    {
                        KravNumber = kravkNumber
                    };
                    await context.KravNumberGenerators.AddAsync(kravNumberGenerator).ConfigureAwait(true);

                }).ConfigureAwait(true);


                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Krav krav = await context.Kravs.FindAsync(id).ConfigureAwait(true);
            context.Kravs.Remove((Krav)krav);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Krav>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Kravs
                                                .Include(k => k.PolitikkRisk)
                                                    .ThenInclude(k => k.Politikk)
                                                        .ThenInclude(p => p.PortfolioKlient)
                                                .Include(k => k.Region)
                                                .Include(i => i.Incident)
                                                .Include(p => p.KravStatus)
                                                .OrderBy(n => n.KravNumber)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Krav> GetAsync(int id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Kravs
                                                .Include(k => k.PolitikkRisk)
                                                    .ThenInclude(k => k.Politikk)
                                                        .ThenInclude(p => p.PortfolioKlient)
                                                .Include(k => k.Region)
                                                .Include(i => i.Incident)
                                                .Include(p => p.KravStatus)
                                                .FirstOrDefaultAsync(e => e.KravNumber == id)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Krav>> GetByPolitikkRiskAsync(Guid politikRiskId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Kravs
                                                .Include(k => k.PolitikkRisk)
                                                    .ThenInclude(k => k.Politikk)
                                                        .ThenInclude(p => p.PortfolioKlient)
                                                .Include(k => k.Region)
                                                .Include(i => i.Incident)
                                                .Include(p => p.KravStatus)
                                                .Where(e => e.PolitikkRiskID == politikRiskId)
                                                .OrderBy(n => n.KravNumber)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Krav>> GetByPortfolioKlientAsync(Guid portfolioKlientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Kravs
                                                .Include(k => k.PolitikkRisk)
                                                    .ThenInclude(k => k.Politikk)
                                                        .ThenInclude(p => p.PortfolioKlient)
                                                .Include(k => k.Region)
                                                .Include(i => i.Incident)
                                                .Include(p => p.KravStatus)
                                                .Where(e => e.PolitikkRisk.Politikk.PortfolioKlientID == portfolioKlientId)
                                                .OrderBy(n => n.KravNumber)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Krav krav)
        {
            if (krav == null)
            {
                throw new ArgumentNullException(nameof(krav));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.Kravs.Update((Krav)krav);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
