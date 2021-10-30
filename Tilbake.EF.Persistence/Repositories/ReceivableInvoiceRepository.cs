using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ReceivableInvoiceRepository : Repository<ReceivableInvoice>, IReceivableInvoiceRepository
    {
        public ReceivableInvoiceRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
