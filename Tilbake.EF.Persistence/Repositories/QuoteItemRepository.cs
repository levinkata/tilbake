using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class QuoteItemRepository : Repository<QuoteItem>, IQuoteItemRepository
    {
        public QuoteItemRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<AllRisk> GetAllRisk(Guid id)
        {
            var result = (from q in _context.QuoteItems
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.AllRisks on r.AllRiskId equals a.Id
                          where q.Id == id && r.AllRiskId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<IEnumerable<QuoteItem>> GetByQuoteId(Guid quoteId)
        {
            return await Task.Run(() => _context.QuoteItems
                                                .Include(q => q.CoverType)
                                                .Where(e => e.QuoteId == quoteId));
        }

        public async Task<Building> GetBuilding(Guid id)
        {
            var result = (from q in _context.QuoteItems
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Buildings on r.BuildingId equals a.Id
                          where q.Id == id && r.BuildingId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<Content> GetContent(Guid id)
        {
            var result = (from q in _context.QuoteItems
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Contents on r.ContentId equals a.Id
                          where q.Id == id && r.ContentId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<House> GetHouse(Guid id)
        {
            var result = (from q in _context.QuoteItems
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Houses on r.HouseId equals a.Id
                          where q.Id == id && r.HouseId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<Motor> GetMotor(Guid id)
        {
            var result = (from q in _context.QuoteItems
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.Motors on r.MotorId equals a.Id
                          where q.Id == id && r.MotorId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }

        public async Task<ExcessBuyBack> GetExcessBuyBack(Guid id)
        {
            var result = (from q in _context.QuoteItems
                          join c in _context.ClientRisks on q.ClientRiskId equals c.Id
                          join r in _context.Risks on c.RiskId equals r.Id
                          join a in _context.ExcessBuyBacks on r.ExcessBuyBackId equals a.Id
                          where q.Id == id && r.ExcessBuyBackId != null
                          select a).FirstOrDefault();

            return await Task.FromResult(result);
        }
    }
}