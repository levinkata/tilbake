using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPolicyService
    {
        Task<IEnumerable<PolicyResource>> GetAllAsync(Guid portfolioClientId);
        Task<IEnumerable<PolicyResource>> GetByPorfolioClientIdAsync(Guid portfolioClientId);
        Task<PolicyResource> GetByIdAsync(Guid id);
        Task<PolicyResource> GetCurrentPolicyAsync(Guid portfolioClientId);
        Task<int> AddAsync(PolicyObjectResource resource);
        Task<int> QuoteToPolicy(QuotePolicyObjectResource resource);
        Task<int> UpdateAsync(PolicyResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PolicyResource resource);
    }
}