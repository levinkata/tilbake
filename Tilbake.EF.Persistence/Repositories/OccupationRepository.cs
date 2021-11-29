using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class OccupationRepository : Repository<Occupation>, IOccupationRepository
    {
        public OccupationRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}