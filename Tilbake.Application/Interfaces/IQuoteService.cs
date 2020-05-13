using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IQuoteService
    {
        Task<QuotesViewModel> GetAllAsync();
        Task<QuotesViewModel> GetklientAsync(Guid klientId);
        Task<QuoteViewModel> GetAsync(Guid id);
        Task<QuoteViewModel> GetByQuoteNumberAsync(int quoteNumber);
        Task<int> AddAsync(QuoteViewModel model);
        Task<int> UpdateAsync(QuoteViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
