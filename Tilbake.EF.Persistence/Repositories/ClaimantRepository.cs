using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClaimantRepository : Repository<Claimant>, IClaimantRepository
    {
        public ClaimantRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}