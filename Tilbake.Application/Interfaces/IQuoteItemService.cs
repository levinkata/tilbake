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
        Task<int> UpdateQuoteItemRiskItemAsync(QuoteItemRiskItemResource resource);
        Task<int> UpdateQuoteItemContentAsync(QuoteItemContentResource resource);
        Task<int> UpdateQuoteItemHouseAsync(QuoteItemHouseResource resource);
        Task<int> UpdateQuoteItemMotorAsync(QuoteItemMotorResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
