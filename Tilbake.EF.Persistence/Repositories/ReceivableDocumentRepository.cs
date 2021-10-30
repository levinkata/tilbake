using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ReceivableDocumentRepository : Repository<ReceivableDocument>, IReceivableDocumentRepository
    {
        public ReceivableDocumentRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
