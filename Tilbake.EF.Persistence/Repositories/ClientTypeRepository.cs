using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientTypeRepository : Repository<ClientType>, IClientTypeRepository
    {
        public ClientTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}