using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ResidenceTypeRepository : Repository<ResidenceType>, IResidenceTypeRepository
    {
        public ResidenceTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
