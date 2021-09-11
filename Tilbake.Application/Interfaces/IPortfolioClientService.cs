using System;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioClientService
    {
        Task<PortfolioClientResource> GetByIdAsync(Guid id);
        Task<IEnumerable<PortfolioClientResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId);
        Task<int> AddClientAsync(ClientSaveResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid portfolioId, Guid clientId);
    }
}