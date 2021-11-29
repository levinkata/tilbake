using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MotorMakeRepository : Repository<MotorMake>, IMotorMakeRepository
    {
        public MotorMakeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}