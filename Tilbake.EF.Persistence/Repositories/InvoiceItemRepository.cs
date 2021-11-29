using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class InvoiceItemRepository : Repository<InvoiceItem>, IInvoiceItemRepository
    {
        public InvoiceItemRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
