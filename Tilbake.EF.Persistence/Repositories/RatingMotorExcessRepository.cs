using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RatingMotorExcessRepository : Repository<RatingMotorExcess>, IRatingMotorExcessRepository
    {
        public RatingMotorExcessRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
