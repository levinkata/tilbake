using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Quote>> GetByPortfolioAsync(Guid portfolioId)
        {
            return await Task.Run(() => _context.Quotes
                                                .Include(e => e.QuoteItems)
                                                    .ThenInclude(p => p.ClientRisk)
                                                        .ThenInclude(r => r.Client)
                                                .Where(k => k.QuoteItems.FirstOrDefault().ClientRisk.Client.PortfolioClients.FirstOrDefault().PortfolioId == portfolioId)
                                                .OrderBy(n => n.QuoteNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Quote>> GetByPortfolioClientAsync(Guid portfolioClientId)
        {
            return await Task.Run(() => _context.Quotes
                                                .Include(q => q.QuoteStatus)
                                                .Include(d => d.QuoteItems)
                                                    .ThenInclude(p => p.ClientRisk)
                                                        .ThenInclude(r => r.Client)
                                                            .ThenInclude(k => k.PortfolioClients)
                                                .Where(k => k.QuoteItems.FirstOrDefault().ClientRisk.Client.PortfolioClients.FirstOrDefault().Id == portfolioClientId)
                                                .OrderBy(n => n.QuoteNumber).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Quote> GetByQuoteNumberAsync(int quoteNumber)
        {
            return await Task.Run(() => _context.Quotes
                                                .Include(b => b.QuoteStatus)
                                                .Include(b => b.Client)
                                                .Where(e => e.QuoteNumber == quoteNumber)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }
    }
}
