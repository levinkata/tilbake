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
    public class PolitikkRepository : IPolitikkRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PolitikkRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Politikk politikk)
        {
            if (politikk == null)
            {
                throw new ArgumentNullException(nameof(politikk));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();
                var politikkNumber = PolitikkNumber.Get(context);

                await Task.Run(async () =>
                {
                    politikk.ID = Guid.NewGuid();
                    politikk.PolitikkNumber = politikkNumber.ToString(CultureInfo.CurrentCulture);
                    await context.Politikks.AddAsync((Politikk)politikk).ConfigureAwait(true);

                    PolitikkNumberGenerator politikkNumberGenerator = new PolitikkNumberGenerator
                    {
                        PolitikkNumber = politikkNumber
                    };
                    await context.PolitikkNumberGenerators.AddAsync(politikkNumberGenerator).ConfigureAwait(true);

                }).ConfigureAwait(true);


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

            Politikk politikk = await context.Politikks.FindAsync(id).ConfigureAwait(true);
            context.Politikks.Remove((Politikk)politikk);
            return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Politikk>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Politikks
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Klient)
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Portfolio)
                                                .Include(i => i.Insurer)
                                                .Include(p => p.PolitikkStatus)
                                                .Include(p => p.PolitikkType)
                                                .Include(p => p.SalesType)
                                                .Include(p => p.PolitikkRisks)
                                                .OrderBy(n => n.PolitikkNumber)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Politikk> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Politikks
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Klient)
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Portfolio)
                                                .Include(i => i.Insurer)
                                                .Include(p => p.PolitikkStatus)
                                                .Include(p => p.PolitikkType)
                                                .Include(p => p.SalesType)
                                                .Include(p => p.PolitikkRisks)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Politikk>> GetKlientPolitikkAsync(Guid klientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Politikks
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Klient)
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Portfolio)
                                                .Include(i => i.Insurer)
                                                .Include(p => p.PolitikkStatus)
                                                .Include(p => p.PolitikkType)
                                                .Include(p => p.SalesType)
                                                .Include(p => p.PolitikkRisks)
                                                .Where(e => e.PortfolioKlient.KlientID == klientId)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Politikk>> GetPortfolioPolitikkAsync(Guid portfolioId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => context.Politikks
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Klient)
                                                .Include(k => k.PortfolioKlient)
                                                    .ThenInclude(k => k.Portfolio)
                                                .Include(i => i.Insurer)
                                                .Include(p => p.PolitikkStatus)
                                                .Include(p => p.PolitikkType)
                                                .Include(p => p.SalesType)
                                                .Include(p => p.PolitikkRisks)
                                                .Where(e => e.PortfolioKlient.PortfolioID == portfolioId)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Politikk politikk)
        {
            if (politikk == null)
            {
                throw new ArgumentNullException(nameof(politikk));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                context.Politikks.Update((Politikk)politikk);
                return await Task.Run(() => context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
