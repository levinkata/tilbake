using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IQuoteService
    {
        Task<IEnumerable<QuoteResource>> GetAllAsync();
        Task<IEnumerable<QuoteResource>> GetByPortfolioAsync(Guid portfolioId);
        Task<IEnumerable<QuoteResource>> GetByPortfolioClientAsync(Guid portfolioClientId);
        Task<QuoteResource> GetByIdAsync(Guid id);
        Task<QuoteResource> GetByQuoteNumberAsync(int quoteNumber);
        Task<QuoteResource> AddAsync(QuoteObjectResource resource);
        Task<QuoteResource> UpdateAsync(QuoteResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(QuoteResource resource);
    }
}
