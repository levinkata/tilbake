using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class ReceivableInvoiceRepository : Repository<ReceivableInvoice>, IReceivableInvoiceRepository
    {
        public ReceivableInvoiceRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}
