using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class RatingMotorDiscountRepository : Repository<RatingMotorDiscount>, IRatingMotorDiscountRepository
    {
        public RatingMotorDiscountRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
