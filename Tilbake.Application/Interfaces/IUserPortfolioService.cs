using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IUserPortfolioService
    {
        Task<IEnumerable<PortfolioResource>> GetByUserIdAsync(string aspNetUserId);
        Task<IEnumerable<PortfolioResource>> GetByNotUserIdAsync(string aspNetUserId);
        void AddRange(UserPortfolioResource resources);
        void DeleteRange(UserPortfolioResource resources);
    }
}
