using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class MotorMakeRepository : Repository<MotorMake>, IMotorMakeRepository
    {
        public MotorMakeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}