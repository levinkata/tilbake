using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class RoofTypeRepository : Repository<RoofType>, IRoofTypeRepository
    {
        public RoofTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
