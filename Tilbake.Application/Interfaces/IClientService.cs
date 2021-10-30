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
        Task<IEnumerable<ClientBulkResource>> GetBulkByPortfolioIdAsync(Guid portfolioId);
        Task<ClientResource> GetByClientIdAsync(Guid portfolioId, Guid clientId);
        void ImportBulk(UpLoadFileResource resource);
        void Add(PortfolioClientSaveResource resource);
        void AddBulk(Guid portfolioId);
        void Update(ClientResource resource);
        void Delete(Guid id);
    }
}