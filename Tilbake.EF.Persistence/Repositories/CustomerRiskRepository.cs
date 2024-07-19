using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class CustomerRiskRepository : Repository<CustomerRisk>, ICustomerRiskRepository
    {
        public CustomerRiskRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}