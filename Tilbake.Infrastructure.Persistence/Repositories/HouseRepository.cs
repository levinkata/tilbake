using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}