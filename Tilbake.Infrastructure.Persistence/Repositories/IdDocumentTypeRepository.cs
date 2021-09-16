using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class IdDocumentTypeRepository : Repository<IdDocumentType>, IIdDocumentTypeRepository
    {
        public IdDocumentTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
