using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PortfolioPolicyFeeRepository : Repository<PortfolioPolicyFee>, IPortfolioPolicyFeeRepository
    {
        public PortfolioPolicyFeeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
