using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PolicyRiskRepository : Repository<PolicyRisk>, IPolicyRiskRepository
    {
        public PolicyRiskRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<AllRisk> GetAllRisk(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.CustomerRisks on q.CustomerRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.AllRisks on r.AllRiskId equals a.Id
                          where q.Id == id && r.AllRiskId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<AllRiskSpecified> GetAllRiskSpecified(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.CustomerRisks on q.CustomerRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.AllRiskSpecifieds on r.AllRiskSpecifiedId equals a.Id
                          where q.Id == id && r.AllRiskSpecifiedId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<Building> GetBuilding(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.CustomerRisks on q.CustomerRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Buildings on r.BuildingId equals a.Id
                          where q.Id == id && r.BuildingId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<PolicyRisk>> GetByPolicyId(Guid policyId)
        {
            return await _context.PolicyRisks
                                    .Include(q => q.CoverType)
                                    .Where(e => e.PolicyId == policyId).ToListAsync();
        }

        public async Task<Content> GetContent(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.CustomerRisks on q.CustomerRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Contents on r.ContentId equals a.Id
                          where q.Id == id && r.ContentId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<House> GetHouse(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.CustomerRisks on q.CustomerRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Houses on r.HouseId equals a.Id
                          where q.Id == id && r.HouseId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<Motor> GetMotor(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.CustomerRisks on q.CustomerRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Motors on r.MotorId equals a.Id
                          where q.Id == id && r.MotorId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<decimal> GetPremiumByPortfolioCustomerId(Guid portfolioCustomerId)
        {
            var result = _context.PolicyRisks
                                        .Where(e => e.Policy.PortfolioCustomerId == portfolioCustomerId)
                                        .Sum(r => r.Premium);

            return await Task.FromResult(result);
        }

        public async Task<decimal> GetSumInsuredByPortfolioCustomerId(Guid portfolioCustomerId)
        {
            var result = _context.PolicyRisks
                                        .Where(e => e.Policy.PortfolioCustomerId == portfolioCustomerId)
                                        .Sum(r => r.SumInsured);

            return await Task.FromResult(result);
        }

        public async Task<Travel> GetTravel(Guid id)
        {
            var result = (from q in _context.PolicyRisks
                          join c in _context.CustomerRisks on q.CustomerRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Travels on r.TravelId equals a.Id
                          where q.Id == id && r.TravelId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }
    }
}