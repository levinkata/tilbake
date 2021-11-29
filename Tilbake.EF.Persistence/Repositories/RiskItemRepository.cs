using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RiskItemRepository : Repository<RiskItem>, IRiskItemRepository
    {
        public RiskItemRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
