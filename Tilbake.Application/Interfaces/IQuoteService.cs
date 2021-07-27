﻿using System;
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
        Task<QuoteResource> GetFirstOrDefaultAsync(Guid id);
        Task<int> AddAsync(QuoteObjectResource resource);
        Task<int> UpdateAsync(QuoteResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(QuoteResource resource);



    }
}
