using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ExcessBuyBackRepository : Repository<ExcessBuyBack>, IExcessBuyBackRepository
    {
        public ExcessBuyBackRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}