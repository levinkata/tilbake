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
    public class QuoteRepository : IQuoteRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public QuoteRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Quote quote, List<QuoteItem> quoteItems)
        {
            if (quote == null)
            {
                throw new ArgumentNullException(nameof(quote));
            }

            if (quoteItems == null)
            {
                throw new ArgumentNullException(nameof(quoteItems));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await Task.Run(async () =>
                {
                    var quoteNumber = QuoteNumbers.Get(_context);

                    quote.ID = Guid.NewGuid();
                    quote.QuoteNumber = quoteNumber;
                    await _context.Quotes.AddAsync((Quote)quote).ConfigureAwait(true);

                    foreach (var c in quoteItems)
                    {
                        QuoteItem quoteItem = new QuoteItem()
                        {
                            ID = Guid.NewGuid(),
                            QuoteID = quote.ID,
                            KlientRiskID = c.KlientRiskID,
                            CoverTypeID = c.CoverTypeID,
                            InsurerID = c.InsurerID,
                            SumInsured = c.SumInsured,
                            Premium = c.Premium,
                            Excess = c.Excess
                        };
                        await _context.QuoteItems.AddAsync((QuoteItem)quoteItem).ConfigureAwait(true);
                    }

                    QuoteNumberGenerator quoteNumberGenerator = new QuoteNumberGenerator
                    {
                        QuoteNumber = quoteNumber
                    };
                    await _context.QuoteNumberGenerators.AddAsync(quoteNumberGenerator).ConfigureAwait(true);

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

            Quote quote = await _context.Quotes.FindAsync(id).ConfigureAwait(true);
            _context.Quotes.Remove((Quote)quote);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Quote>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Quotes
                                                .Include(q => q.QuoteStatus)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.CoverType)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.KlientRisk)
                                                        .ThenInclude(r => r.Klient)
                                                .OrderBy(n => n.QuoteNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Quote> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Quotes
                                                .Include(q => q.QuoteStatus)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.CoverType)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.KlientRisk)
                                                        .ThenInclude(k => k.Klient)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<Quote> GetByQuoteNumberAsync(int quoteNumber)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Quotes
                                                .Include(q => q.QuoteStatus)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.CoverType)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.KlientRisk)
                                                        .ThenInclude(k => k.Klient)
                                                .SingleOrDefaultAsync(e => e.QuoteNumber == quoteNumber)).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Quote>> GetklientAsync(Guid klientId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Quotes
                                                .Include(q => q.QuoteStatus)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.CoverType)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.KlientRisk)
                                                        .ThenInclude(r => r.Klient)
                                                .Where(k => k.QuoteItems.FirstOrDefault().KlientRisk.KlientID == klientId)
                                                .OrderBy(n => n.QuoteNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException(nameof(quote));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Quotes.Update((Quote)quote);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
