using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class RiskRepository : Repository<Risk>, IRiskRepository
    {
        public RiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}