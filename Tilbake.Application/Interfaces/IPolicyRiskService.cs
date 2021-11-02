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
        Task<decimal> GetSumInsuredByPortfolioClientIdAsync(Guid portfolioClientId);
        Task<decimal> GetPremiumByPortfolioClientIdAsync(Guid portfolioClientId);
        Task<int> AddAsync(PolicyRiskSaveResource resource);
        Task<int> UpdateAsync(PolicyRiskResource resource);
        Task<int> UpdatePolicyRiskBuilding(PolicyRiskBuildingResource resource);
        Task<int> UpdatePolicyRiskRiskItem(PolicyRiskRiskItemResource resource);
        Task<int> UpdatePolicyRiskContent(PolicyRiskContentResource resource);
        Task<int> UpdatePolicyRiskHouse(PolicyRiskHouseResource resource);
        Task<int> UpdatePolicyRiskMotor(PolicyRiskMotorResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}