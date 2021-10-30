using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class BodyTypeRepository : Repository<BodyType>, IBodyTypeRepository
    {
        public BodyTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}