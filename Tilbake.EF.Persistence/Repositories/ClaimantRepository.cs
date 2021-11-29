using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClaimantRepository : Repository<Claimant>, IClaimantRepository
    {
        public ClaimantRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}