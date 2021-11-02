using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IQuoteItemService
    {
        Task<QuoteItemResource> GetByIdAsync(Guid id);
        Task<QuoteItemObjectResource> GetRisksAsync(Guid id);
        Task<IEnumerable<QuoteItemResource>> GetByQuoteIdAsync(Guid quoteId);
        Task<int> UpdateAsync(QuoteItemResource resource);
        Task<int> UpdateQuoteItemRiskItem(QuoteItemRiskItemResource resource);
        Task<int> UpdateQuoteItemBuilding(QuoteItemBuildingResource resource);
        Task<int> UpdateQuoteItemContent(QuoteItemContentResource resource);
        Task<int> UpdateQuoteItemExcessBuyBack(QuoteItemExcessBuyBackResource resource);
        Task<int> UpdateQuoteItemHouse(QuoteItemHouseResource resource);
        Task<int> UpdateQuoteItemMotor(QuoteItemMotorResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
