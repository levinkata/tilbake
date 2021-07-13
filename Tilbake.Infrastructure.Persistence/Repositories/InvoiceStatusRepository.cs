using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class InvoiceStatusRepository : Repository<InvoiceStatus>, IInvoiceStatusRepository
    {
        public InvoiceStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}