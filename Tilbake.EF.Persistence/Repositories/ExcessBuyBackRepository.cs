using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ExcessBuyBackRepository : Repository<ExcessBuyBack>, IExcessBuyBackRepository
    {
        public ExcessBuyBackRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}