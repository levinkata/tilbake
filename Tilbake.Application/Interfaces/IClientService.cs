using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;
using Tilbake.Domain.Enums;

namespace Tilbake.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientResource>> GetAllAsync();
        Task<ClientResource> GetByIdAsync(Guid id);
        Task<ClientResource> GetByIdNumberAsync(string idNumber);
        Task<ClientResource> GetByPolicyIdAsync(Guid policyId);
        Task<IEnumerable<ClientResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<IEnumerable<ClientBulkResource>> GetBulkByPortfolioIdAsync(Guid portfolioId);
        Task<ClientResource> GetByClientIdAsync(Guid portfolioId, Guid clientId);
        Task<int> ImportBulkAsync(UpLoadFileResource resource);
        Task<int> AddAsync(PortfolioClientSaveResource resource);
        Task<int> AddBulkAsync(Guid portfolioId);
        Task<int> UpdateAsync(ClientResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ClientResource resource);
        Task<int> DeleteBulkAsync(List<ClientBulkResource> resources);
    }
}