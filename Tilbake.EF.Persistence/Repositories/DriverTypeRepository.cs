using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class DriverTypeRepository : Repository<DriverType>, IDriverTypeRepository
    {
        public DriverTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}