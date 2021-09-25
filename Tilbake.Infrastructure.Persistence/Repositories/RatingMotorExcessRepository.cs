using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class RatingMotorExcessRepository : Repository<RatingMotorExcess>, IRatingMotorExcessRepository
    {
        public RatingMotorExcessRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
