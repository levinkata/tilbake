using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientStatusRepository : Repository<ClientStatus>, IClientStatusRepository
    {
        public ClientStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}