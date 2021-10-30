using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RatingMotorPremiumRepository : Repository<RatingMotorPremium>, IRatingMotorPremiumRepository
    {
        public RatingMotorPremiumRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
