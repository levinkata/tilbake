using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class RoofTypeRepository : Repository<RoofType>, IRoofTypeRepository
    {
        public RoofTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
