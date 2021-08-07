using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class MotorRepository : Repository<Motor>, IMotorRepository
    {
        public MotorRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}