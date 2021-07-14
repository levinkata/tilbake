using System;
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

        public async Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId)
        {
            return await Task.Run(() => _context.PortfolioClients
                                                .SingleOrDefault(e => e.PortfolioId == portfolioId && e.ClientId == clientId).Id);
        }
    }
}