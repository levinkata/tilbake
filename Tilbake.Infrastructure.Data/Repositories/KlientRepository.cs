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
using Tilbake.Infrastructure.Data.Generators;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class KlientRepository : IKlientRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public KlientRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Guid portfolioId, Klient klient)
        {
            if (klient == null)
            {
                throw new ArgumentNullException(nameof(klient));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();
                var klientNumber = KlientNumbers.Get(_context);

                await Task.Run(async () =>
                {
                    klient.ID = Guid.NewGuid();
                    klient.KlientNumber = klientNumber;
                    await _context.Klients.AddAsync((Klient)klient).ConfigureAwait(true);

                    if (portfolioId != Guid.Empty)
                    {
                        PortfolioKlient portfolioKlient = new PortfolioKlient()
                        {
                            ID = Guid.NewGuid(),
                            PortfolioID = portfolioId,
                            KlientID = klient.ID
                        };
                        await _context.PortfolioKlients.AddAsync((PortfolioKlient)portfolioKlient).ConfigureAwait(true);
                    }

                    KlientNumberGenerator klientNumberGenerator = new KlientNumberGenerator
                    {
                        KlientNumber = klientNumber
                    };
                    await _context.KlientNumberGenerators.AddAsync(klientNumberGenerator).ConfigureAwait(true);

                }).ConfigureAwait(true);

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

            Klient klient = await _context.Klients.FindAsync(id).ConfigureAwait(true);
            _context.Klients.Remove((Klient)klient);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Klient>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .OrderBy(n => n.LastName)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Klient> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<Klient> GetByIdNumberAsync(string idNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .SingleOrDefaultAsync(e => e.IDNumber == idNumber)).ConfigureAwait(true);
        }

        public async Task<Klient> GetByKlientNumberAsync(int klientNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .SingleOrDefaultAsync(e => e.KlientNumber == klientNumber)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Klient>> GetByNameAsync(string klientName)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .Where(a => a.FirstName.Contains(klientName, StringComparison.OrdinalIgnoreCase) ||
                                                a.LastName.Contains(klientName, StringComparison.OrdinalIgnoreCase))
                                                .OrderBy(n => n.LastName).ToListAsync()).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Klient klient)
        {
            if (klient == null)
            {
                throw new ArgumentNullException(nameof(klient));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Klients.Update((Klient)klient);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
