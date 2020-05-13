using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IQuoteStatusRepository
    {
        Task<IEnumerable<QuoteStatus>> GetAllAsync();
        Task<QuoteStatus> GetAsync(Guid id);
        Task<int> AddAsync(QuoteStatus quoteStatus);
        Task<int> UpdateAsync(QuoteStatus quoteStatus);
        Task<int> DeleteAsync(Guid id);
    }
}
