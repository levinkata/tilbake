using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PolicyStatusRepository : Repository<PolicyStatus>, IPolicyStatusRepository
    {
        public PolicyStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}