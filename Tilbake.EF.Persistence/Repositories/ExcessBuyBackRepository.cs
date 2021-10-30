using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ExcessBuyBackRepository : Repository<ExcessBuyBack>, IExcessBuyBackRepository
    {
        public ExcessBuyBackRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}