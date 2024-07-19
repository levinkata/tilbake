using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core.Models;

namespace Tilbake.Core.Interfaces
{
    public interface IPolicyRiskRepository : IRepository<PolicyRisk>
    {
        Task<IEnumerable<PolicyRisk>> GetByPolicyId(Guid policyId);
        Task<decimal> GetPremiumByPortfolioCustomerId(Guid portfolioCustomerId);
        Task<decimal> GetSumInsuredByPortfolioCustomerId(Guid portfolioCustomerId);
        Task<AllRisk> GetAllRisk(Guid id);
        Task<AllRiskSpecified> GetAllRiskSpecified(Guid id);
        Task<Building> GetBuilding(Guid id);
        Task<Content> GetContent(Guid id);
        Task<House> GetHouse(Guid id);
        Task<Motor> GetMotor(Guid id);
        Task<Travel> GetTravel(Guid id);
    }    
}