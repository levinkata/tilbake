using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientCarrierRepository : Repository<ClientCarrier>, IClientCarrierRepository
    {
        public ClientCarrierRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}