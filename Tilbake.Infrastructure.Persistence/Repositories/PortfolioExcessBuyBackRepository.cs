using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PortfolioExcessBuyBackRepository : Repository<PortfolioExcessBuyBack>, IPortfolioExcessBuyBackRepository
    {
        public PortfolioExcessBuyBackRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
