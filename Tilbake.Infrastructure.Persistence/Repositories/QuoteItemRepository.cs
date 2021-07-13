using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class QuoteItemRepository : Repository<QuoteItem>, IQuoteItemRepository
    {
        public QuoteItemRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}