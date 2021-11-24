using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PortfolioAdministrationFeeRepository : Repository<PortfolioAdministrationFee>, IPortfolioAdministrationFeeRepository
    {
        public PortfolioAdministrationFeeRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<PortfolioAdministrationFee>> GetByPortfolioId(Guid portfolioId)
        {
            return await _context.PortfolioAdministrationFees
                                .Where(r => r.PortfolioId == portfolioId)
                                .Include(r => r.Insurer)
                                .OrderBy(n => n.Insurer.Name).AsNoTracking().ToListAsync();
        }
    }
}
