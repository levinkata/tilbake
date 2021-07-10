using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IUserPortfolioService
    {
        Task<IEnumerable<AspnetUserPortfolioResource>> GetByUserIdAsync(string aspNetUserId);
        Task<int> AddAsync(AspnetUserPortfolioResource resource);
        Task<int> AddRangeAsync(UserPortfolioResource resources);
        Task<int> DeleteAsync(AspnetUserPortfolioResource resource);
        Task<int> DeleteRangeAsync(UserPortfolioResource resources);
    }
}
