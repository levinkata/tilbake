using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioService
    {
        Task<IEnumerable<PortfolioResource>> GetAllAsync();
        //Task<IEnumerable<PortfolioResource>> GetByUserIdAsync(string aspNetUserId);
        //Task<IEnumerable<PortfolioResource>> GetByNotUserIdAsync(string aspNetUserId);
        Task<PortfolioResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PortfolioSaveResource resource);
        Task<int> UpdateAsync(PortfolioResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PortfolioResource resource);
    }
}