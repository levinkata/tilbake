using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CustomerStatusRepository : Repository<CustomerStatus>, ICustomerStatusRepository
    {
        public CustomerStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}