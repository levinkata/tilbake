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
        void Add(QuoteObjectResource resource);
        void Update(QuoteResource resource);
        void Delete(Guid id);
    }
}
