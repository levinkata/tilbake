using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CustomerBulkRepository : Repository<CustomerBulk>, ICustomerBulkRepository
    {
        public CustomerBulkRepository(TilbakeDbContext context) : base(context)
        {

        }






    }
}