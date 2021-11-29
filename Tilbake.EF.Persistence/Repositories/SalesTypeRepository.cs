using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class SalesTypeRepository : Repository<SalesType>, ISalesTypeRepository
    {
        public SalesTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}