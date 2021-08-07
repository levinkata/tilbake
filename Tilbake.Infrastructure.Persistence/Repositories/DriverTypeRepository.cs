using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class DriverTypeRepository : Repository<DriverType>, IDriverTypeRepository
    {
        public DriverTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}