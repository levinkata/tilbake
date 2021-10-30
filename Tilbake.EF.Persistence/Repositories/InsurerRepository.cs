using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class InsurerRepository : Repository<Insurer>, IInsurerRepository
    {
        public InsurerRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}