using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}