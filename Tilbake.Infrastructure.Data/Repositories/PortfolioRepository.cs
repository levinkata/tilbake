using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.Infrastructure.Data.Repositories
{
    public class PortfolioRepository : IPortfolioRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PortfolioRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(Portfolio portfolio)
        {
            if (portfolio == null)
            {
                throw new ArgumentNullException(nameof(portfolio));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                portfolio.ID = Guid.NewGuid();
                await _context.Portfolios.AddAsync((Portfolio)portfolio).ConfigureAwait(true);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            Portfolio portfolio = await _context.Portfolios.FindAsync(id).ConfigureAwait(true);
            _context.Portfolios.Remove((Portfolio)portfolio);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Portfolios
                                                .Include(p => p.PortfolioKlients)
                                                    .ThenInclude(k => k.Klient)
                                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Portfolio> GetAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Portfolios
                                                .Include(p => p.PortfolioKlients)
                                                    .ThenInclude(k => k.Klient)
                                                .FirstOrDefaultAsync(e => e.ID == id)).ConfigureAwait(true);
        }

        public async Task<int> UpdateAsync(Portfolio portfolio)
        {
            if (portfolio == null)
            {
                throw new ArgumentNullException(nameof(portfolio));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                _context.Portfolios.Update((Portfolio)portfolio);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }
    }
}
