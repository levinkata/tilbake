using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MotorCycleTypeRepository : Repository<MotorCycleType>, IMotorCycleTypeRepository
    {
        public MotorCycleTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}