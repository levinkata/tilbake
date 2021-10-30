using Tilbake.Core.Models;
using Tilbake.Core.Interfaces;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class AllRiskRepository : Repository<AllRisk>, IAllRiskRepository
    {
        public AllRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}