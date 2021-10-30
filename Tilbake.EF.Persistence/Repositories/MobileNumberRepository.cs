using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MobileNumberRepository : Repository<MobileNumber>, IMobileNumberRepository
    {
        public MobileNumberRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
