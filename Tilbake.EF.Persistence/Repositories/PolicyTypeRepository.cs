using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PolicyTypeRepository : Repository<PolicyType>, IPolicyTypeRepository
    {
        public PolicyTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}