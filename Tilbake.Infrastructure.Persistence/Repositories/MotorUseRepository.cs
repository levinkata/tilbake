using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class MotorUseRepository : Repository<MotorUse>, IMotorUseRepository
    {
        public MotorUseRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}