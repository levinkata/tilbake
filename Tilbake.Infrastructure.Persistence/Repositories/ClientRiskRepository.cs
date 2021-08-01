using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientRiskRepository : Repository<ClientRisk>, IClientRiskRepository
    {
        public ClientRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}