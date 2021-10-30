using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class InvoiceStatusRepository : Repository<InvoiceStatus>, IInvoiceStatusRepository
    {
        public InvoiceStatusRepository(TilbakeDbContext context) : base(context)
        {

        }
    }
}