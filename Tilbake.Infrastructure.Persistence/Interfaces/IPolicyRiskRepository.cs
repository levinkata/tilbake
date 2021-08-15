using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IPolicyRiskRepository : IRepository<PolicyRisk>
    {
        Task<IEnumerable<PolicyRisk>> GetByPolicyIdAsync(Guid policyId);
        Task<AllRisk> GetAllRiskAsync(Guid id);
        Task<Content> GetContentAsync(Guid id);
        Task<House> GetHouseAsync(Guid id);
        Task<Motor> GetMotorAsync(Guid id);
    }    
}