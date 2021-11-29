using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class MobileNumberRepository : Repository<MobileNumber>, IMobileNumberRepository
    {
        public MobileNumberRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
