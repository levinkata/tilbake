using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BuildingConditionRepository : Repository<BuildingCondition>, IBuildingConditionRepository
    {
        public BuildingConditionRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}