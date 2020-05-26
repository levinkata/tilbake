using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IInvoiceStatusService
    {
        Task<InvoiceStatusesViewModel> GetAllAsync();
        Task<InvoiceStatusViewModel> GetAsync(Guid id);
        Task<int> AddAsync(InvoiceStatusViewModel model);
        Task<int> UpdateAsync(InvoiceStatusViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
