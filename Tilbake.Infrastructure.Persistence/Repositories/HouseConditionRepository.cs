using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class HouseConditionRepository : Repository<HouseCondition>, IHouseConditionRepository
    {
        public HouseConditionRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
