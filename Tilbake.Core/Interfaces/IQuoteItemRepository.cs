using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IQuoteItemRepository : IRepository<QuoteItem>
    {
        Task<IEnumerable<QuoteItem>> GetByQuoteIdAsync(Guid quoteId);
        Task<AllRisk> GetAllRiskAsync(Guid id);
        Task<Building> GetBuildingAsync(Guid id);
        Task<Content> GetContentAsync(Guid id);
        Task<ExcessBuyBack> GetExcessBuyBackAsync(Guid id);
        Task<House> GetHouseAsync(Guid id);
        Task<Motor> GetMotorAsync(Guid id);
    }
}