using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<IEnumerable<Invoice>> GetAllAsync();
        Task<IEnumerable<Invoice>> GetKlientAsync(Guid klientId);
        Task<Invoice> GetAsync(Guid id);
        Task<Invoice> GetByInvoiceNumberAsync(int invoiceNumber);
        Task<int> AddAsync(Invoice invoice, List<InvoiceItem> invoiceItems);
        Task<int> UpdateAsync(Invoice invoice);
        Task<int> DeleteAsync(Guid id);
    }
}
