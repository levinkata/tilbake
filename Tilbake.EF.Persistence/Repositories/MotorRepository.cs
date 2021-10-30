using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MotorRepository : Repository<Motor>, IMotorRepository
    {
        public MotorRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}