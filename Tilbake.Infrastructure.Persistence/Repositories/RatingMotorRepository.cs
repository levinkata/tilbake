using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class RatingMotorRepository : Repository<RatingMotor>, IRatingMotorRepository
    {
        public RatingMotorRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
