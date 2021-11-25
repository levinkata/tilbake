using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPolicyRiskRepository : IRepository<PolicyRisk>
    {
        Task<IEnumerable<PolicyRisk>> GetByPolicyId(Guid policyId);
        Task<decimal> GetPremiumByPortfolioClientId(Guid portfolioClientId);
        Task<decimal> GetSumInsuredByPortfolioClientId(Guid portfolioClientId);
        Task<AllRisk> GetAllRisk(Guid id);
        Task<Building> GetBuilding(Guid id);
        Task<Content> GetContent(Guid id);
        Task<House> GetHouse(Guid id);
        Task<Motor> GetMotor(Guid id);
    }    
}