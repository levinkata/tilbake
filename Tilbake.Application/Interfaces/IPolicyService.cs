using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicyResource>> GetAllAsync();
        Task<IEnumerable<PolicyResource>> GetByPorfolioClientIdAsync(Guid portfolioClientId);
        Task<PolicyResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PolicyObjectResource resource);
        Task<int> QuoteToPolicy(QuotePolicyObjectResource resource);
        Task<int> UpdateAsync(PolicyResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PolicyResource resource);
    }
}