using System;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioClientService
    {
        Task<PortfolioClientResource> GetByIdAsync(Guid id);
        Task<PortfolioClientResource> FindAsync(Guid id);
        Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId);
        Task<int> AddClientAsync(ClientSaveResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid portfolioId, Guid clientId);
    }
}