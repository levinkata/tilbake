using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ResidenceTypeRepository : Repository<ResidenceType>, IResidenceTypeRepository
    {
        public ResidenceTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
