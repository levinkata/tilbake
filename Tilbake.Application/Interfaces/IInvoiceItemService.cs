using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceItemService
    {
        Task<InvoiceItemResource> GetByIdAsync(Guid id);
        Task<InvoiceItemResource> GetFirstOrDefaultAsync(Guid id);
        Task<IEnumerable<InvoiceItemResource>> GetByInvoiceIdAsync(Guid invoiceId);
        void Update(InvoiceItemResource resource);
        void Delete(Guid id);
    }
}
