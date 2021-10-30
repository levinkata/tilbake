using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class InsurerBranchRepository : Repository<InsurerBranch>, IInsurerBranchRepository
    {
        public InsurerBranchRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}