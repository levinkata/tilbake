using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<IEnumerable<Client>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<ClientResponse> GetByIdAsync(Guid id);
        Task<ClientResponse> AddAsync(Client client);
        Task<ClientResponse> AddToPortfolioAsync(Guid portfolioId, Client client);
        Task<ClientResponse> UpdateAsync(Guid id, Client client);
        Task<ClientResponse> DeleteAsync(Guid id);
        Task<ClientResponse> DeleteAsync(Client client);
    }
}