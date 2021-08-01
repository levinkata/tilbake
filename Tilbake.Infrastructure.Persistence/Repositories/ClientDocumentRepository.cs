using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ClientDocumentRepository : Repository<ClientDocument>, IClientDocumentRepository
    {
        public ClientDocumentRepository(TilbakeDbContext context) : base(context)
        {

        }


    }
}
