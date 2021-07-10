using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IUserPortfolioRepository
    {
        Task<IEnumerable<AspnetUserPortfolio>> GetByUserIdAsync(string aspNetUserId);
        Task<int> AddAsync(AspnetUserPortfolio aspnetUserPortfolio);
        Task<int> AddRangeAsync(IEnumerable<AspnetUserPortfolio> aspnetUserPortfolios);
        Task<int> DeleteAsync(AspnetUserPortfolio aspnetUserPortfolio);
        Task<int> DeleteRangeAsync(IEnumerable<AspnetUserPortfolio> aspnetUserPortfolios);

    }
}
