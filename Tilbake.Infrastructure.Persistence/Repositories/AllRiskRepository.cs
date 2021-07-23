using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class AllRiskRepository : Repository<AllRisk>, IAllRiskRepository
    {
        public AllRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}