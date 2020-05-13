using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetAllAsync();
        Task<IEnumerable<Quote>> GetklientAsync(Guid klientId);
        Task<Quote> GetAsync(Guid id);
        Task<Quote> GetByQuoteNumberAsync(int quoteNumber);
        Task<int> AddAsync(Quote quote, List<QuoteItem> quoteItems);
        Task<int> UpdateAsync(Quote quote);
        Task<int> DeleteAsync(Guid id);
    }
}
