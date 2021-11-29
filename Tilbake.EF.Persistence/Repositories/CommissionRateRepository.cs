using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CommissionRateRepository : Repository<CommissionRate>, ICommissionRateRepository
    {
        public CommissionRateRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
