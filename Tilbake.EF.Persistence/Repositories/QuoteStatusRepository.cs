using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class QuoteStatusRepository : Repository<QuoteStatus>, IQuoteStatusRepository
    {
        public QuoteStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}