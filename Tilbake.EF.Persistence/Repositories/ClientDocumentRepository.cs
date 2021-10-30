using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClientDocumentRepository : Repository<ClientDocument>, IClientDocumentRepository
    {
        public ClientDocumentRepository(TilbakeDbContext context) : base(context)
        {

        }


    }
}
