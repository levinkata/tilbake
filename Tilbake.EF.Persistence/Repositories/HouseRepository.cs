using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class HouseRepository : Repository<House>, IHouseRepository
    {
        public HouseRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}