using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        Task<IEnumerable<Quote>> GetByPortfolioId(Guid portfolioId);
        Task<IEnumerable<Quote>> GetByPortfolioCustomerId(Guid portfolioCustomerId);
        Task<Quote> GetByQuoteNumberAsync(int quoteNumber);
    }
}
