using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PortfolioAdministrationFeeRepository : Repository<PortfolioAdministrationFee>, IPortfolioAdministrationFeeRepository
    {
        public PortfolioAdministrationFeeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
