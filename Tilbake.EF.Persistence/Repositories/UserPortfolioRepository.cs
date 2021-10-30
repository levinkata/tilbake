using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;

namespace Tilbake.EF.Persistence.Repositories
{
    public class UserPortfolioRepository : Repository<AspnetUserPortfolio>, IUserPortfolioRepository
    {
        public UserPortfolioRepository(TilbakeDbContext context) : base(context)
        {

        }

/*         public async Task<IEnumerable<Portfolio>> GetByNotUserIdAsync(string aspNetUserId)
        {
            return await _context.Portfolios
                                .Where(c => !c.AspnetUserPortfolios
                                .Any(u => u.AspNetUserId == aspNetUserId))
                                .Include(c => c.PortfolioClients)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        }
 */
/*         public async Task<IEnumerable<Portfolio>> GetByUserIdAsync(string aspNetUserId)
        {
            return await _context.Portfolios
                                .Where(c => c.AspnetUserPortfolios
                                .Any(p => p.AspNetUserId == aspNetUserId))
                                .Include(c => c.PortfolioClients)
                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync();
        } */
    }
}
