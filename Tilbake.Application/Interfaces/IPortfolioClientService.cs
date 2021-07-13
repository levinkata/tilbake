using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPortfolioClientService
    {
        Task<IEnumerable<ClientResource>> GetByPortfoloId(Guid portfolioId);
        Task<ClientResource> GetByClientId(Guid portfolioId, Guid clientId);
        Task<PortfolioClientResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PortfolioClientSaveResource resource);
        Task<int> AddClientAsync(ClientSaveResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<bool> ExistsAsync(Guid portfolioId, Guid clientId);
    }
}