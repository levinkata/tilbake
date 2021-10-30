using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PortfolioAdministrationFeeRepository : Repository<PortfolioAdministrationFee>, IPortfolioAdministrationFeeRepository
    {
        public PortfolioAdministrationFeeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
