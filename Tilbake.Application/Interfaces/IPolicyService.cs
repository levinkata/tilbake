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
        Task<PolicyResource> AddAsync(PolicyObjectResource resource);
        Task<PolicyResource> QuoteToPolicy(QuotePolicyObjectResource resource);
        Task<PolicyResource> UpdateAsync(PolicyResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PolicyResource resource);
    }
}