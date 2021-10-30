using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PolicyStatusRepository : Repository<PolicyStatus>, IPolicyStatusRepository
    {
        public PolicyStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}