using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BuildingConditionRepository : Repository<BuildingCondition>, IBuildingConditionRepository
    {
        public BuildingConditionRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}