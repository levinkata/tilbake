using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class MobileNumberRepository : Repository<MobileNumber>, IMobileNumberRepository
    {
        public MobileNumberRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
