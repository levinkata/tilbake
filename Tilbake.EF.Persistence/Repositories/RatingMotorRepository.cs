using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RatingMotorRepository : Repository<RatingMotor>, IRatingMotorRepository
    {
        public RatingMotorRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
