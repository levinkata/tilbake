using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IQuoteItemService
    {
        Task<QuoteItemResource> GetByIdAsync(Guid id);
        Task<QuoteItemResource> GetFirstOrDefaultAsync(Guid id);
        Task<QuoteItemObjectResource> GetRisksAsync(Guid id);
        Task<IEnumerable<QuoteItemResource>> GetByQuoteIdAsync(Guid quoteId);
        Task<int> UpdateAsync(QuoteItemResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
