using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        public CustomerTypeRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}