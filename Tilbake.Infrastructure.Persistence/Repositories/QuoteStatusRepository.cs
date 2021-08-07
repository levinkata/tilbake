using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class QuoteStatusRepository : Repository<QuoteStatus>, IQuoteStatusRepository
    {
        public QuoteStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}