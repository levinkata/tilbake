using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class CommissionRateRepository : Repository<CommissionRate>, ICommissionRateRepository
    {
        public CommissionRateRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
