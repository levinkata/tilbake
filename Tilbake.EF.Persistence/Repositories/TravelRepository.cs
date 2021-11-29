using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class TravelRepository : Repository<Travel>, ITravelRepository
    {
        public TravelRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}