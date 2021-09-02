using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientBulkRepository : Repository<ClientBulk>, IClientBulkRepository
    {
        public ClientBulkRepository(TilbakeDbContext context) : base(context)
        {

        }






    }
}