using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPolicyRiskService
    {
        Task<IEnumerable<PolicyRiskResource>> GetAllAsync();
        Task<IEnumerable<PolicyRiskResource>> GetByPolicyIdAsync(Guid policyId);
        Task<PolicyRiskResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PolicyRiskSaveResource resource);
        Task<int> UpdateAsync(PolicyRiskResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PolicyRiskResource resource);
    }
}