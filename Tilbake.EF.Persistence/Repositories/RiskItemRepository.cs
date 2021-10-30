using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RiskItemRepository : Repository<RiskItem>, IRiskItemRepository
    {
        public RiskItemRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
