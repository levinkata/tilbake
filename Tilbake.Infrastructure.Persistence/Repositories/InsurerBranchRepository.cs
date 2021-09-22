using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class InsurerBranchRepository : Repository<InsurerBranch>, IInsurerBranchRepository
    {
        public InsurerBranchRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}