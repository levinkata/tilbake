using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientResource>> GetAllAsync();
        Task<ClientResource> GetByIdAsync(Guid id);
        Task<ClientResource> GetByIdNumberAsync(string idNumber);
        Task<ClientResource> GetByPolicyIdAsync(Guid policyId);
        Task<IEnumerable<ClientResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<ClientResource> GetByClientId(Guid portfolioId, Guid clientId);
        Task<int> AddAsync(ClientSaveResource resource);
        Task<int> UpdateAsync(ClientResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ClientResource resource);
    }
}