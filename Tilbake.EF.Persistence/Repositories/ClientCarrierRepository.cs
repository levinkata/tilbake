using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientCarrierRepository : Repository<ClientCarrier>, IClientCarrierRepository
    {
        public ClientCarrierRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}