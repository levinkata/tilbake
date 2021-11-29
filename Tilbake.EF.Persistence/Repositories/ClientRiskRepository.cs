using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientRiskRepository : Repository<ClientRisk>, IClientRiskRepository
    {
        public ClientRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}