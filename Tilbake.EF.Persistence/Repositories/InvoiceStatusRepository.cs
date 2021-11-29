using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class InvoiceStatusRepository : Repository<InvoiceStatus>, IInvoiceStatusRepository
    {
        public InvoiceStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}