using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class RatingMotorPremiumRepository : Repository<RatingMotorPremium>, IRatingMotorPremiumRepository
    {
        public RatingMotorPremiumRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
