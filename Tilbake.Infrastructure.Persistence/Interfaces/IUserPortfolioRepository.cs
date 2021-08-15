using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IUserPortfolioRepository : IRepository<AspnetUserPortfolio>
    {
        Task<IEnumerable<Portfolio>> GetByNotUserIdAsync(string aspNetUserId);
        Task<IEnumerable<Portfolio>> GetByUserIdAsync(string aspNetUserId);
    }
}
