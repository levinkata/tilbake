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
        void Update(QuoteItemResource resource);
        void UpdateQuoteItemRiskItem(QuoteItemRiskItemResource resource);
        void UpdateQuoteItemBuilding(QuoteItemBuildingResource resource);
        void UpdateQuoteItemContent(QuoteItemContentResource resource);
        void UpdateQuoteItemExcessBuyBack(QuoteItemExcessBuyBackResource resource);
        void UpdateQuoteItemHouse(QuoteItemHouseResource resource);
        void UpdateQuoteItemMotor(QuoteItemMotorResource resource);
        void Delete(Guid id);
    }
}
