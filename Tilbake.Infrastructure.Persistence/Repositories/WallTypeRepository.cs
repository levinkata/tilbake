using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class WallTypeRepository : Repository<WallType>, IWallTypeRepository
    {
        public WallTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
