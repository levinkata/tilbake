using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CommissionRateRepository : Repository<CommissionRate>, ICommissionRateRepository
    {
        public CommissionRateRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
