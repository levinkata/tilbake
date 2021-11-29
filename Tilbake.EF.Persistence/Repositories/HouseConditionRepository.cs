using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class HouseConditionRepository : Repository<HouseCondition>, IHouseConditionRepository
    {
        public HouseConditionRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
