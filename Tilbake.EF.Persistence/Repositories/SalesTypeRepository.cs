using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class SalesTypeRepository : Repository<SalesType>, ISalesTypeRepository
    {
        public SalesTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}