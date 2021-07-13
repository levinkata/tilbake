using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        Task<IEnumerable<Quote>> GetByPortfolioAsync(Guid portfolioId);
        Task<IEnumerable<Quote>> GetByPortfolioClientAsync(Guid portfolioClientId);
        Task<Quote> GetByQuoteNumberAsync(int quoteNumber);
    }
}
