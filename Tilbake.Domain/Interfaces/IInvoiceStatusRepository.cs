using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IInvoiceStatusRepository
    {
        Task<IEnumerable<InvoiceStatus>> GetAllAsync();
        Task<InvoiceStatus> GetAsync(Guid id);
        Task<int> AddAsync(InvoiceStatus invoiceStatus);
        Task<int> UpdateAsync(InvoiceStatus invoiceStatus);
        Task<int> DeleteAsync(Guid id);
    }
}
