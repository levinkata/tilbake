using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RoofTypeRepository : Repository<RoofType>, IRoofTypeRepository
    {
        public RoofTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
