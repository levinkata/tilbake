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
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<Client> GetByIdNumberAsync(string idNumber)
        {
            return await Task.Run(() => _context.Clients
                                                .Include(b => b.ClientType)
                                                .Include(b => b.Country)
                                                .Include(b => b.Gender)
                                                .Include(b => b.MaritalStatus)
                                                .Include(b => b.Occupation)
                                                .Include(b => b.Title)
                                                .Where(e => e.IdNumber == idNumber)
                                                .FirstOrDefaultAsync());
        }

        public async Task<Client> GetByClientId(Guid portfolioId, Guid clientId)
        {
            return await Task.Run(() => _context.Clients
                                                .Where(c => c.PortfolioClients
                                                .Any(p => p.PortfolioId == portfolioId && p.ClientId == clientId))
                                                .Include(c => c.PortfolioClients)
                                                .FirstOrDefaultAsync());
        }

        public async Task<IEnumerable<Client>> GetByPortfolioId(Guid portfolioId)
        {
            return await Task.Run(() => _context.Clients
                                                .Where(c => c.PortfolioClients
                                                .Any(p => p.PortfolioId == portfolioId))
                                                .Include(c => c.PortfolioClients)
                                                .OrderBy(n => n.LastName)
                                                .AsNoTracking());
        }
    }
}