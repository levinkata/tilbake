using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PolicyTypeRepository : Repository<PolicyType>, IPolicyTypeRepository
    {
        public PolicyTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}