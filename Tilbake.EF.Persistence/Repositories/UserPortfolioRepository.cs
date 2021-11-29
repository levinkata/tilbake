using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

namespace Tilbake.EF.Persistence.Repositories
{
    public class UserPortfolioRepository : Repository<AspnetUserPortfolio>, IUserPortfolioRepository
    {
        public UserPortfolioRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Portfolio>> GetByNotUserId(string aspNetUserId)
        {
            return await _context.Portfolios
                                .Where(c => !c.AspnetUserPortfolios
                                .Any(u => u.AspNetUserId == aspNetUserId))
                                .Include(c => c.PortfolioClients)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Portfolio>> GetByUserId(string aspNetUserId)
        {
            return await _context.Portfolios
                                .Where(c => c.AspnetUserPortfolios
                                .Any(p => p.AspNetUserId == aspNetUserId))
                                .Include(c => c.PortfolioClients)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        } 
    }
}
