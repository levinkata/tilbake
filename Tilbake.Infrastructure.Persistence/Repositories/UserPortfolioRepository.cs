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
    public class UserPortfolioRepository : IUserPortfolioRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public UserPortfolioRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(AspnetUserPortfolio aspnetUserPortfolio)
        {
            if (aspnetUserPortfolio == null)
            {
                throw new ArgumentNullException(nameof(aspnetUserPortfolio));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await _context.AspnetUserPortfolios.AddAsync(aspnetUserPortfolio).ConfigureAwait(true);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> AddRangeAsync(IEnumerable<AspnetUserPortfolio> aspnetUserPortfolios)
        {
            if (aspnetUserPortfolios == null)
            {
                throw new ArgumentNullException(nameof(aspnetUserPortfolios));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await _context.AspnetUserPortfolios.AddRangeAsync(aspnetUserPortfolios).ConfigureAwait(true);
                return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
            }
            catch (DbUpdateException ex)
            {
                return ex.HResult;
            }
        }

        public async Task<int> DeleteAsync(AspnetUserPortfolio aspnetUserPortfolio)
        {
            if (aspnetUserPortfolio == null)
            {
                throw new ArgumentNullException(nameof(aspnetUserPortfolio));
            }

            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            await Task.Run(() => _context.AspnetUserPortfolios.Remove(aspnetUserPortfolio)).ConfigureAwait(true);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteRangeAsync(IEnumerable<AspnetUserPortfolio> aspnetUserPortfolios)
        {
            if (aspnetUserPortfolios == null)
            {
                throw new ArgumentNullException(nameof(aspnetUserPortfolios));
            }

            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            await Task.Run(() => _context.AspnetUserPortfolios.RemoveRange(aspnetUserPortfolios)).ConfigureAwait(true);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<AspnetUserPortfolio>> GetByUserIdAsync(string aspNetUserId)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.AspnetUserPortfolios
                                                .Include(p => p.Portfolio)
                                                .Where(e => e.AspNetUserId == aspNetUserId)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }
    }
}
