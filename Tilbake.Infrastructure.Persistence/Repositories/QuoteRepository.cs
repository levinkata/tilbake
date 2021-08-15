using Microsoft.EntityFrameworkCore;
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
