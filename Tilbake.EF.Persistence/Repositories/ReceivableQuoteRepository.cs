using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ReceivableQuoteRepository : Repository<ReceivableQuote>, IReceivableQuoteRepository
    {
        public ReceivableQuoteRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
