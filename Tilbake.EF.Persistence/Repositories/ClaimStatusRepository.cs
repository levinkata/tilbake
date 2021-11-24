using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClaimStatusRepository : Repository<ClaimStatus>, IClaimStatusRepository
    {
        public ClaimStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}