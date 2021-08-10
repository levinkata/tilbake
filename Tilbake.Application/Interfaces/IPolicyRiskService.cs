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
        Task<PolicyRiskObjectResource> GetRisksAsync(Guid id);
        Task<PolicyRiskResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PolicyRiskSaveResource resource);
        Task<int> UpdateAsync(PolicyRiskResource resource);
        Task<int> UpdatePolicyRiskRiskItemAsync(PolicyRiskRiskItemResource resource);
        Task<int> UpdatePolicyRiskContentAsync(PolicyRiskContentResource resource);
        Task<int> UpdatePolicyRiskHouseAsync(PolicyRiskHouseResource resource);
        Task<int> UpdatePolicyRiskMotorAsync(PolicyRiskMotorResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(PolicyRiskResource resource);
    }
}