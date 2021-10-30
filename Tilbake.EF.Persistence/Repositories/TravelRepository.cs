using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class TravelRepository : Repository<Travel>, ITravelRepository
    {
        public TravelRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}