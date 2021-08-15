using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IQuoteItemRepository : IRepository<QuoteItem>
    {
        Task<IEnumerable<QuoteItem>> GetByQuoteIdAsync(Guid quoteId);
        Task<AllRisk> GetAllRiskAsync(Guid id);
        Task<Content> GetContentAsync(Guid id);
        Task<House> GetHouseAsync(Guid id);
        Task<Motor> GetMotorAsync(Guid id);
    }
}