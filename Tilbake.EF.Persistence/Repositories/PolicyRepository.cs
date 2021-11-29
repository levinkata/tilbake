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
    public class PolicyRepository : Repository<Policy>, IPolicyRepository
    {
        public PolicyRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Policy>> GetByPorfolioClientId(Guid portfolioClientId)
        {
            return await _context.Policies
                                .Where(p => p.PortfolioClientId == portfolioClientId)
                                .Include(p => p.PaymentMethod)
                                .Include(p => p.PolicyStatus)
                                .Include(p => p.PolicyType)
                                .Include(p => p.SalesType)
                                .Include(p => p.InsurerBranch)
                                .Include(p => p.InsurerBranch.Insurer)
                                .Include(p => p.PortfolioClient)
                                .OrderByDescending((p => p.CoverStartDate)).AsNoTracking().ToListAsync();
        }

        public async Task<Policy> GetCurrentPolicy(Guid portfolioClientId)
        {
            return await _context.Policies
                                .Where(e => e.PortfolioClientId == portfolioClientId)
                                .Include(p => p.PaymentMethod)
                                .Include(p => p.PolicyStatus)
                                .Include(p => p.PolicyType)
                                .Include(p => p.SalesType)
                                .Include(p => p.InsurerBranch)
                                .Include(p => p.InsurerBranch.Insurer)
                                .Include(p => p.PortfolioClient).FirstOrDefaultAsync();
        }
    }
}