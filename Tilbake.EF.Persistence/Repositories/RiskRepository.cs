using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RiskRepository : Repository<Risk>, IRiskRepository
    {
        public RiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}