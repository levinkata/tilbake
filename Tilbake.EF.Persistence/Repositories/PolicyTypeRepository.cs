using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PolicyTypeRepository : Repository<PolicyType>, IPolicyTypeRepository
    {
        public PolicyTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}