using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Infrastructure.Persistence.Repositories
{
    public class PortfolioClientRepository : Repository<PortfolioClient>, IPortfolioClientRepository
    {
        public PortfolioClientRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<PortfolioClient> AddClientAsync(Guid portfolioId, Client client)
        {
            await _context.Clients.AddAsync(client).ConfigureAwait(true);
            PortfolioClient portfolioClient = new PortfolioClient()
            {
                Id = Guid.NewGuid(),
                PortfolioId = portfolioId,
                ClientId = client.Id
            };
            await _context.PortfolioClients.AddAsync(portfolioClient).ConfigureAwait(true);
            await _context.SaveChangesAsync().ConfigureAwait(true);
            return portfolioClient;
        }

        public async Task<bool> ExistsAsync(Guid portfolioId, Guid clientId)
        {
            return await Task.Run(() => _context.PortfolioClients
                                                .Any(e => e.PortfolioId == portfolioId && e.ClientId == clientId))
                                                .ConfigureAwait(true);
        }

        public async Task<Client> GetByClientId(Guid portfolioId, Guid clientId)
        {
            return await Task.Run(() => _context.Clients
                                                .Where(c => c.PortfolioClients
                                                .Any(p => p.PortfolioId == portfolioId && p.ClientId == clientId))
                                                .Include(c => c.PortfolioClients)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<Client>> GetByPortfolioId(Guid portfolioId)
        {
            return await Task.Run(() => _context.Clients
                                                .Where(c => c.PortfolioClients
                                                .Any(p => p.PortfolioId == portfolioId))
                                                .Include(c => c.PortfolioClients)
                                                .OrderBy(n => n.LastName)
                                                .AsNoTracking()).ConfigureAwait(true);
        }
    }
}