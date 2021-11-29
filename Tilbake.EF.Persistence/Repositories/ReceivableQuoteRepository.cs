using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ReceivableQuoteRepository : Repository<ReceivableQuote>, IReceivableQuoteRepository
    {
        public ReceivableQuoteRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
