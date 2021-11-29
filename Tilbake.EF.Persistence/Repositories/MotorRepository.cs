using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MotorRepository : Repository<Motor>, IMotorRepository
    {
        public MotorRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}