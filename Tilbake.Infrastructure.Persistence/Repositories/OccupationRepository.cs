using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        public OccupationRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}