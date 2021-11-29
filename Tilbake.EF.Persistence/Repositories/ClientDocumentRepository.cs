using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientDocumentRepository : Repository<ClientDocument>, IClientDocumentRepository
    {
        public ClientDocumentRepository(TilbakeDbContext context) : base(context)
        {

        }


    }
}
