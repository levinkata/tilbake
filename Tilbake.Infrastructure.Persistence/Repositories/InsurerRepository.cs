using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class InsurerRepository : Repository<Insurer>, IInsurerRepository
    {
        public InsurerRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}