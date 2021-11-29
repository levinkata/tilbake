using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class DriverTypeRepository : Repository<DriverType>, IDriverTypeRepository
    {
        public DriverTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}