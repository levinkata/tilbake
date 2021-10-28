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
        void Add(PolicyRiskSaveResource resource);
        void Update(PolicyRiskResource resource);
        void UpdatePolicyRiskBuilding(PolicyRiskBuildingResource resource);
        void UpdatePolicyRiskRiskItem(PolicyRiskRiskItemResource resource);
        void UpdatePolicyRiskContent(PolicyRiskContentResource resource);
        void UpdatePolicyRiskHouse(PolicyRiskHouseResource resource);
        void UpdatePolicyRiskMotor(PolicyRiskMotorResource resource);
        void Delete(Guid id);
    }
}