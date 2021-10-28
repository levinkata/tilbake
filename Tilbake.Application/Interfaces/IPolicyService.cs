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
        void Add(PolicyObjectResource resource);
        void QuoteToPolicy(QuotePolicyObjectResource resource);
        void Update(PolicyResource resource);
        void Delete(Guid id);
    }
}