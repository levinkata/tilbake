using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientTypeRepository : Repository<ClientType>, IClientTypeRepository
    {
        public ClientTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}