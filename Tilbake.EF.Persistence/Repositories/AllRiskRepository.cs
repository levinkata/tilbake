using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class AllRiskRepository : Repository<AllRisk>, IAllRiskRepository
    {
        public AllRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}