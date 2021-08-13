using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PremiumRepository : Repository<Premium>, IPremiumRepository
    {
        public PremiumRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}