using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class AllRiskSpecifiedRepository : Repository<AllRiskSpecified>, IAllRiskSpecifiedRepository
    {
        public AllRiskSpecifiedRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}