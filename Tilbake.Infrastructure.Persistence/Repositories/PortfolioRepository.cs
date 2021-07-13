using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PortfolioRepository : Repository<Portfolio>, IPortfolioRepository
    {
        public PortfolioRepository(TilbakeDbContext context) : base(context)
        {

        }

        //public async Task<IEnumerable<Portfolio>> GetByNotUserIdAsync(string aspNetUserId)
        //{
        //    return await Task.Run(() => _context.Portfolios
        //                                        .Where(c => c.AspnetUserPortfolios
        //                                        .Any(u => u.AspNetUserId == aspNetUserId))
        //                                        .Include(p => p.PortfolioClients)
        //                                        .Include(u => u.AspnetUserPortfolios)
        //                                        .OrderBy(n => n.Name).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        //}

        //public async Task<IEnumerable<Portfolio>> GetByUserIdAsync(string aspNetUserId)
        //{
        //    return await Task.Run(() => _context.Portfolios
        //                                        .Where(c => !c.AspnetUserPortfolios
        //                                        .Any(u => u.AspNetUserId == aspNetUserId))
        //                                        .OrderBy(n => n.Name).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        //}
    }
}