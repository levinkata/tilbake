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
    public class PortfolioPolicyFeeRepository : Repository<PortfolioPolicyFee>, IPortfolioPolicyFeeRepository
    {
        public PortfolioPolicyFeeRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PortfolioPolicyFee>> GetByPortfolioId(Guid portfolioId)
        {
            return await _context.PortfolioPolicyFees
                                .Where(r => r.PortfolioId == portfolioId)
                                .Include(r => r.Insurer)
                                .OrderBy(n => n.Insurer.Name).AsNoTracking().ToListAsync();
        }
    }
}
