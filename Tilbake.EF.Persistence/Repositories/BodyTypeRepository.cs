using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BodyTypeRepository : Repository<BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}