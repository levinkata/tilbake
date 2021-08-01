using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class UserPortfolioRepository : Repository<AspnetUserPortfolio>, IUserPortfolioRepository
    {

        public UserPortfolioRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Portfolio>> GetByNotUserIdAsync(string aspNetUserId)
        {
            return await Task.Run(() => _context.Portfolios
                                                .Where(c => !c.AspnetUserPortfolios
                                                .Any(u => u.AspNetUserId == aspNetUserId))
                                                .Include(c => c.PortfolioClients)
                                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync());
        }

        public async Task<IEnumerable<Portfolio>> GetByUserIdAsync(string aspNetUserId)
        {
            return await Task.Run(() => _context.Portfolios
                                                .Where(c => c.AspnetUserPortfolios
                                                .Any(p => p.AspNetUserId == aspNetUserId))
                                                .Include(c => c.PortfolioClients)
                                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync());
        }
    }
}
