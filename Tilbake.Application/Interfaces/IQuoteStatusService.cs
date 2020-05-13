using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IQuoteStatusService
    {
        Task<QuoteStatusesViewModel> GetAllAsync();
        Task<QuoteStatusViewModel> GetAsync(Guid id);
        Task<int> AddAsync(QuoteStatusViewModel model);
        Task<int> UpdateAsync(QuoteStatusViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
