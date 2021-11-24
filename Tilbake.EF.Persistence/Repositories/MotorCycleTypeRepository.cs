using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MotorCycleTypeRepository : Repository<MotorCycleType>, IMotorCycleTypeRepository
    {
        public MotorCycleTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}