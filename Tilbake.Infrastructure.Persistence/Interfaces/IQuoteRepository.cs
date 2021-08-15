using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IQuoteRepository : IRepository<Quote>
    {
        Task<bool> IsConvertedToPolicy(Guid id);
    }
}
