using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ClaimStatusRepository : Repository<ClaimStatus>, IClaimStatusRepository
    {
        public ClaimStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}