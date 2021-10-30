using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientBulkRepository : Repository<ClientBulk>, IClientBulkRepository
    {
        public ClientBulkRepository(TilbakeDbContext context) : base(context)
        {

        }






    }
}