using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ReceivableQuoteRepository : Repository<ReceivableQuote>, IReceivableQuoteRepository
    {
        public ReceivableQuoteRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
