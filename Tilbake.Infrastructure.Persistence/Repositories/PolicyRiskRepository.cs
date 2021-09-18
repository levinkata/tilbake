using Microsoft.EntityFrameworkCore;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PolicyRiskRepository : Repository<PolicyRisk>, IPolicyRiskRepository
    {
        public PolicyRiskRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<AllRisk> GetAllRiskAsync(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.AllRisks on r.AllRiskId equals a.Id
                          where q.Id == id && r.AllRiskId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<Building> GetBuildingAsync(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Buildings on r.BuildingId equals a.Id
                          where q.Id == id && r.BuildingId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PolicyRisk>> GetByPolicyIdAsync(Guid policyId)
        {
            return await _context.PolicyRisks
                                    .Include(q => q.CoverType)
                                    .Where(e => e.PolicyId == policyId).ToListAsync();
        }

        public async Task<Content> GetContentAsync(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Contents on r.ContentId equals a.Id
                          where q.Id == id && r.ContentId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<House> GetHouseAsync(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Houses on r.HouseId equals a.Id
                          where q.Id == id && r.HouseId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<Motor> GetMotorAsync(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Motors on r.MotorId equals a.Id
                          where q.Id == id && r.MotorId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }
    }
}