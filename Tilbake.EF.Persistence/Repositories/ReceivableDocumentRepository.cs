using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ReceivableDocumentRepository : Repository<ReceivableDocument>, IReceivableDocumentRepository
    {
        public ReceivableDocumentRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
