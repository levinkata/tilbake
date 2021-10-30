using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientRiskRepository : Repository<ClientRisk>, IClientRiskRepository
    {
        public ClientRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}