using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class TravelRepository : Repository<Travel>, ITravelRepository
    {
        public TravelRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}