using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class WallTypeRepository : Repository<WallType>, IWallTypeRepository
    {
        public WallTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
