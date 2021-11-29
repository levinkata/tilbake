using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PremiumRepository : Repository<Premium>, IPremiumRepository
    {
        public PremiumRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}