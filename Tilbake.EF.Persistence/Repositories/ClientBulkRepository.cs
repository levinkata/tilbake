using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientBulkRepository : Repository<ClientBulk>, IClientBulkRepository
    {
        public ClientBulkRepository(TilbakeDbContext context) : base(context)
        {

        }






    }
}