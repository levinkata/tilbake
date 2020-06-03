using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceService
    {
        Task<InvoicesViewModel> GetAllAsync();
        Task<InvoicesViewModel> GetKlientAsync(Guid klientId);
        Task<InvoiceViewModel> GetAsync(Guid id);
        Task<InvoiceViewModel> GetByInvoiceNumberAsync(int invoiceNumber);
        Task<int> AddAsync(InvoiceViewModel model);
        Task<int> UpdateAsync(InvoiceViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
