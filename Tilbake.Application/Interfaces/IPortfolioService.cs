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
        void Add(PortfolioSaveResource resource);
        void Update(PortfolioResource resource);
        void Delete(Guid id);
    }
}