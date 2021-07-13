using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceStatusService
    {
        Task<IEnumerable<InvoiceStatusResource>> GetAllAsync();
        Task<InvoiceStatusResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(InvoiceStatusSaveResource resource);
        Task<int> UpdateAsync(InvoiceStatusResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(InvoiceStatusResource resource);
    }
}