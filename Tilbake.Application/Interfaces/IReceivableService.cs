using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IReceivableService
    {
        Task<IEnumerable<ReceivableResource>> GetAllAsync();
        Task<IEnumerable<ReceivableResource>> GetByInvoiceIdAsync(Guid invoiceId);
        Task<ReceivableResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ReceivableSaveResource resource);
        Task<int> AddQuote(ReceivableSaveResource resource);
        Task<int> UpdateAsync(ReceivableResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
