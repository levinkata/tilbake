using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientStatusRepository : Repository<ClientStatus>, IClientStatusRepository
    {
        public ClientStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}