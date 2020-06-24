using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;
using Tilbake.Infrastructure.Data.Generators;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class KlientRepository : BaseRepository, IKlientRepository
    {
        public KlientRepository(TilbakeDbContext context) : base(context) { }

        public async Task AddAsync(Guid portfolioId, Klient klient)
        {
            if (klient == null)
            {
                throw new ArgumentNullException(nameof(klient));
            }

            await Task.Run(async () =>
            {
                var klientNumber = KlientNumbers.Get(_context);

                klient.Id = Guid.NewGuid();
                klient.KlientNumber = klientNumber;
                await _context.Klients.AddAsync((Klient)klient).ConfigureAwait(true);

                if (portfolioId != Guid.Empty)
                {
                    PortfolioKlient portfolioKlient = new PortfolioKlient()
                    {
                        Id = Guid.NewGuid(),
                        PortfolioId = portfolioId,
                        KlientId = klient.Id
                    };
                    await _context.PortfolioKlients.AddAsync((PortfolioKlient)portfolioKlient).ConfigureAwait(true);
                }

                KlientNumberGenerator klientNumberGenerator = new KlientNumberGenerator
                {
                    KlientNumber = klientNumber
                };
                await _context.KlientNumberGenerators.AddAsync(klientNumberGenerator).ConfigureAwait(true);

            }).ConfigureAwait(true);
        }

        public void DeleteAsync(Klient klient)
        {
            _context.Klients.Remove((Klient)klient);
        }

        public async Task<IEnumerable<Klient>> GetAllAsync()
        {
            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .OrderBy(n => n.LastName)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Klient> GetAsync(Guid id, bool includeRelated)
        {
            if (includeRelated)
                return await Task.Run(() => _context.Klients
                                                    .Include(b => b.Land)
                                                    .Include(b => b.Occupation)
                                                    .Include(b => b.Title)
                                                    .FirstOrDefaultAsync(e => e.Id == id)).ConfigureAwait(true);

                return await Task.Run(() => _context.Klients
                                                    .FirstOrDefaultAsync(e => e.Id == id)).ConfigureAwait(true);                                                    
        }

        public async Task<Klient> GetByIdNumberAsync(string idNumber)
        {
            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .SingleOrDefaultAsync(e => e.IdNumber == idNumber)).ConfigureAwait(true);
        }

        public async Task<Klient> GetByKlientNumberAsync(int klientNumber)
        {
            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .SingleOrDefaultAsync(e => e.KlientNumber == klientNumber)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Klient>> GetByNameAsync(string klientName)
        {
            return await Task.Run(() => _context.Klients
                                                .Include(b => b.Land)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .Where(a => a.FirstName.Contains(klientName, StringComparison.OrdinalIgnoreCase) ||
                                                a.LastName.Contains(klientName, StringComparison.OrdinalIgnoreCase))
                                                .OrderBy(n => n.LastName).ToListAsync()).ConfigureAwait(true);
        }

        public void UpdateAsync(Klient klient)
        {
            _context.Klients.Update((Klient)klient);
        }
    }
}
