using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class HouseConditionRepository : Repository<HouseCondition>, IHouseConditionRepository
    {
        public HouseConditionRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
