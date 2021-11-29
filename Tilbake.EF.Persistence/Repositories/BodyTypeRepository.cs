using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BodyTypeRepository : Repository<BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}