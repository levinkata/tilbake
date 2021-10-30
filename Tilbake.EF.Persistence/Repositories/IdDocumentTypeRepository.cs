using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class IdDocumentTypeRepository : Repository<IdDocumentType>, IIdDocumentTypeRepository
    {
        public IdDocumentTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
