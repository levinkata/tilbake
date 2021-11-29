using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class QuoteStatusRepository : Repository<QuoteStatus>, IQuoteStatusRepository
    {
        public QuoteStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}