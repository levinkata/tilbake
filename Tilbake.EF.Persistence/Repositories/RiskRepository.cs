using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RiskRepository : Repository<Risk>, IRiskRepository
    {
        public RiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}