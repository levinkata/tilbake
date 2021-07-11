using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
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

                portfolio.Id = Guid.NewGuid();
                await _context.Portfolios.AddAsync(portfolio).ConfigureAwait(true);

                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<Portfolio> portfolios)
        {
            if (portfolios == null)
            {
                throw new ArgumentNullException(nameof(portfolios));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await _context.Portfolios.AddRangeAsync(portfolios).ConfigureAwait(true);
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

        public async Task<int> DeleteAsync(Portfolio portfolio)
        {
            if (portfolio == null)
            {
                throw new ArgumentNullException(nameof(portfolio));
            }

            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            await Task.Run(() => _context.Portfolios.Remove(portfolio)).ConfigureAwait(true);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<Portfolio> portfolios)
        {
            if (portfolios == null)
            {
                throw new ArgumentNullException(nameof(portfolios));
            }
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            await Task.Run(() => _context.Portfolios.RemoveRange(portfolios)).ConfigureAwait(true);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Portfolio>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Portfolios.OrderBy(n => n.Name).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Portfolio>> GetByUserIdAsync(string aspNetUserId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Portfolios
                                                .Where(c => c.AspnetUserPortfolios
                                                .Any(u => u.AspNetUserId == aspNetUserId))
                                                .Include(p => p.PortfolioClients)
                                                .Include(u => u.AspnetUserPortfolios)
                                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<Portfolio> GetByIdAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Portfolios.FirstOrDefaultAsync(e => e.Id == id)).ConfigureAwait(true);
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

                _context.Portfolios.Update(portfolio);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<IEnumerable<Portfolio>> GetByNotUserIdAsync(string aspNetUserId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.Portfolios
                                                .Where(c => !c.AspnetUserPortfolios
                                                .Any(u => u.AspNetUserId == aspNetUserId))
                                                .OrderBy(n => n.Name).AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }
    }
}