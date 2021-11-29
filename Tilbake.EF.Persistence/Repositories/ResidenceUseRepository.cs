using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ResidenceUseRepository : Repository<ResidenceUse>, IResidenceUseRepository
    {
        public ResidenceUseRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
