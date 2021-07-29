using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PolicyRiskRepository : Repository<PolicyRisk>, IPolicyRiskRepository
    {
        public PolicyRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}