using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioClientService
    {
        Task<PortfolioClientResource> GetByIdAsync(Guid id);
        Task<IEnumerable<PortfolioClientResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<PortfolioClientResource> GetByIdNumberAsync(Guid portfolioId, string idNumber);
        Task<PortfolioClientResource> GetByPortfolioClientAsync(Guid portfolioId, Guid clientId);
        Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId);
        Task<int> AddAsync(PortfolioClientSaveResource resource);
        Task<int> UpdateAsync(PortfolioClientResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid portfolioId, Guid clientId);
    }
}