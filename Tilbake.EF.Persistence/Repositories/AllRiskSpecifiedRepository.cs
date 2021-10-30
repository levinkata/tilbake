using Tilbake.Core.Models;
using Tilbake.Core.Interfaces;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class AllRiskSpecifiedRepository : Repository<AllRiskSpecified>, IAllRiskSpecifiedRepository
    {
        public AllRiskSpecifiedRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}