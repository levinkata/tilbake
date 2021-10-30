using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ResidenceTypeRepository : Repository<ResidenceType>, IResidenceTypeRepository
    {
        public ResidenceTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
