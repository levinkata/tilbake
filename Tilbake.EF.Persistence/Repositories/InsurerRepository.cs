using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class InsurerRepository : Repository<Insurer>, IInsurerRepository
    {
        public InsurerRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}