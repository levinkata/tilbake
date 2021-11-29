using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class QuoteRepository : Repository<Quote>, IQuoteRepository
    {
        public QuoteRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Quote>> GetByPortfolioClientId(Guid portfolioClientId)
        {
            return await _context.Quotes
                                .Where(r => r.PortfolioClientId == portfolioClientId)
                                .Include(r => r.QuoteItems)
                                .Include(r => r.QuoteStatus)
                                .Include(r => r.InsurerBranch)
                                .Include(r => r.PaymentMethod)
                                .Include(r => r.PolicyType)
                                .Include(r => r.SalesType)
                                .Include(r => r.InsurerBranch.Insurer)
                                .Include(r => r.PortfolioClient)
                                .Include(r => r.PortfolioClient.Client)
                                .OrderBy(r => r.QuoteNumber).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Quote>> GetByPortfolioId(Guid portfolioId)
        {
            return await _context.Quotes
                                .Where(r => r.PortfolioClient.PortfolioId == portfolioId)
                                .Include(r => r.QuoteItems)
                                .Include(r => r.QuoteStatus)
                                .Include(r => r.InsurerBranch)
                                .Include(r => r.PaymentMethod)
                                .Include(r => r.PolicyType)
                                .Include(r => r.SalesType)
                                .Include(r => r.InsurerBranch.Insurer)
                                .Include(r => r.PortfolioClient)
                                .Include(r => r.PortfolioClient.Client)
                                .OrderBy(r => r.QuoteNumber).AsNoTracking().ToListAsync();
        }

        public async Task<Quote> GetByQuoteNumberAsync(int quoteNumber)
        {
            return await _context.Quotes
                                .Where(r => r.QuoteNumber == quoteNumber)
                                .Include(r => r.QuoteItems)
                                .Include(r => r.QuoteStatus)
                                .Include(r => r.InsurerBranch)
                                .Include(r => r.PaymentMethod)
                                .Include(r => r.PolicyType)
                                .Include(r => r.SalesType)
                                .Include(r => r.InsurerBranch.Insurer)
                                .Include(r => r.PortfolioClient)
                                .Include(r => r.PortfolioClient.Client)
                                .OrderBy(r => r.QuoteNumber).FirstOrDefaultAsync();
        }
    }
}
