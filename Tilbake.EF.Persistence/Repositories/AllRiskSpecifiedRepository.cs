using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class AllRiskSpecifiedRepository : Repository<AllRiskSpecified>, IAllRiskSpecifiedRepository
    {
        public AllRiskSpecifiedRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}