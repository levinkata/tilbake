using Microsoft.Extensions.DependencyInjection;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PolicyStatusRepository : Repository<PolicyStatus>, IPolicyStatusRepository
    {
        public PolicyStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}