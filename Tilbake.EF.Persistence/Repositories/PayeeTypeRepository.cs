using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PayeeTypeRepository : Repository<PayeeType>, IPayeeTypeRepository
    {
        public PayeeTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}