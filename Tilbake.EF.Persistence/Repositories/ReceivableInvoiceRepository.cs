using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ReceivableInvoiceRepository : Repository<ReceivableInvoice>, IReceivableInvoiceRepository
    {
        public ReceivableInvoiceRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
