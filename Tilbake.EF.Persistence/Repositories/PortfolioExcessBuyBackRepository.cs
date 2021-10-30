using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PortfolioExcessBuyBackRepository : Repository<PortfolioExcessBuyBack>, IPortfolioExcessBuyBackRepository
    {
        public PortfolioExcessBuyBackRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
