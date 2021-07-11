using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class CarrierRepository : Repository<Carrier>, ICarrierRepository
    {
        public CarrierRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
