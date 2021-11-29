using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class WallTypeRepository : Repository<WallType>, IWallTypeRepository
    {
        public WallTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
