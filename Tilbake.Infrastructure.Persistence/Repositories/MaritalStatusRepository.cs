using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class MaritalStatusRepository : Repository<MaritalStatus>, IMaritalStatusRepository
    {
        public MaritalStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}