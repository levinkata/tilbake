using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PortfolioClientRepository : IPortfolioClientRepository
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PortfolioClientRepository(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory ?? throw new ArgumentNullException(nameof(serviceScopeFactory));
        }

        public async Task<int> AddAsync(PortfolioClient portfolioClient)
        {
            if (portfolioClient == null)
            {
                throw new ArgumentNullException(nameof(portfolioClient));
            }

            try
            {
                using var scope = _serviceScopeFactory.CreateScope();
                var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

                await _context.PortfolioClients.AddAsync(portfolioClient).ConfigureAwait(true);
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

            PortfolioClient portfolioClient = await _context.PortfolioClients.FindAsync(id).ConfigureAwait(true);
            _context.PortfolioClients.Remove((PortfolioClient)portfolioClient);
            return await Task.Run(() => _context.SaveChangesAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<PortfolioClient>> GetAllAsync()
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.PortfolioClients
                                                .Include(p => p.Portfolio)
                                                .Include(c => c.Client)
                                                .AsNoTracking().ToListAsync()).ConfigureAwait(true);
        }

        public async Task<PortfolioClient> GetByIdAsync(Guid id)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var _context = scope.ServiceProvider.GetRequiredService<TilbakeDbContext>();

            return await Task.Run(() => _context.PortfolioClients
                                                .Include(p => p.Portfolio)
                                                .Include(c => c.Client)
                                                .FirstOrDefaultAsync(e => e.Id == id)).ConfigureAwait(true);
        }
    }
}
