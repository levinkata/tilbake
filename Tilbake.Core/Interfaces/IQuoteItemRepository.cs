using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IQuoteItemRepository : IRepository<QuoteItem>
    {
        Task<IEnumerable<QuoteItem>> GetByQuoteId(Guid quoteId);
        Task<AllRisk> GetAllRisk(Guid id);
        Task<Building> GetBuilding(Guid id);
        Task<Content> GetContent(Guid id);
        Task<ExcessBuyBack> GetExcessBuyBack(Guid id);
        Task<House> GetHouse(Guid id);
        Task<Motor> GetMotor(Guid id);
    }
}