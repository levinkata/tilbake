using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class BodyTypeRepository : Repository<BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}