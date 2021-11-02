using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceItemService
    {
        Task<InvoiceItemResource> GetByIdAsync(Guid id);
        Task<IEnumerable<InvoiceItemResource>> GetByInvoiceIdAsync(Guid invoiceId);
        Task<int> UpdateAsync(InvoiceItemResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
