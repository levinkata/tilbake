using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RatingMotorDiscountRepository : Repository<RatingMotorDiscount>, IRatingMotorDiscountRepository
    {
        public RatingMotorDiscountRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
