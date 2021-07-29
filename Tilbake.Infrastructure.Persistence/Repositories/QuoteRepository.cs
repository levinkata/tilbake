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
                                                .Include(q => q.QuoteStatus)
                                                .Include(e => e.QuoteItems)
                                                .Include(c => c.PortfolioClient)
                                                .Where(r => r.PortfolioClient.PortfolioId == portfolioId)
                                                .OrderBy(n => n.QuoteNumber).AsNoTracking().ToListAsync());
        }

        public async Task<IEnumerable<Quote>> GetByPortfolioClientAsync(Guid portfolioClientId)
        {
            return await Task.Run(() => _context.Quotes
                                                .Include(q => q.QuoteStatus)
                                                .Include(d => d.QuoteItems)
                                                .Where(e => e.PortfolioClientId == portfolioClientId)
                                                .OrderBy(n => n.QuoteNumber).AsNoTracking().ToListAsync());
        }

        public async Task<Quote> GetByQuoteNumberAsync(int quoteNumber)
        {
            return await Task.Run(() => _context.Quotes
                                                .Include(b => b.QuoteStatus)
                                                .Include(b => b.PortfolioClient)
                                                .Where(e => e.QuoteNumber == quoteNumber)
                                                .FirstOrDefaultAsync());
        }

        public async Task<bool> IsConvertedToPolicy(Guid id)
        {
            var result = await (from q in _context.Quotes
                        join i in _context.QuoteItems on q.Id equals i.QuoteId
                        join p in _context.PolicyRisks on i.ClientRiskId equals p.ClientRiskId
                        where q.Id == id
                        select q).ToListAsync();

            return result.Any();
        }
    }
}
