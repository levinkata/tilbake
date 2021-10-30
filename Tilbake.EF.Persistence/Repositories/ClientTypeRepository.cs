using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientTypeRepository : Repository<ClientType>, IClientTypeRepository
    {
        public ClientTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}