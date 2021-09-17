using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class BuildingConditionRepository : Repository<BuildingCondition>, IBuildingConditionRepository
    {
        public BuildingConditionRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}