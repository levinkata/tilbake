using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tilbake.EF.Persistence.Repositories
{
    public class ReceivableRepository : Repository<Receivable>, IReceivableRepository
    {
        public ReceivableRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Receivable>> GetByInvoiceId(Guid invoiceId)
        {
            return await _context.Receivables
                                .Where(r => r.ReceivableInvoices.Any(p => p.InvoiceId == invoiceId))
                                .OrderBy(n => n.ReceivableDate)
                                .Include(r => r.PaymentType)
                                .Include(r => r.ReceivableDocuments)
                                .Include(r => r.ReceivableInvoices).AsNoTracking().ToListAsync();
        }
    }
}
