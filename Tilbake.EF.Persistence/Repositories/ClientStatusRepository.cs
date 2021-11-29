using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientStatusRepository : Repository<ClientStatus>, IClientStatusRepository
    {
        public ClientStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}