using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class IdDocumentTypeRepository : Repository<IdDocumentType>, IIdDocumentTypeRepository
    {
        public IdDocumentTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
