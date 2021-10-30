using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MotorMakeRepository : Repository<MotorMake>, IMotorMakeRepository
    {
        public MotorMakeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}