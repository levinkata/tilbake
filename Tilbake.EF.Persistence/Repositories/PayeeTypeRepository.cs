using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PayeeTypeRepository : Repository<PayeeType>, IPayeeTypeRepository
    {
        public PayeeTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}