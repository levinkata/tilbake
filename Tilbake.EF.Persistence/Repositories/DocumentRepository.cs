using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class DocumentRepository : Repository<Document>, IDocumentRepository
    {
        public DocumentRepository(TilbakeDbContext context) : base(context)
        {

        }


    }
}
