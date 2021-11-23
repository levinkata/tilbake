using Microsoft.EntityFrameworkCore;
using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Tilbake.EF.Persistence.Repositories
{
    public class PortfolioClientRepository : Repository<PortfolioClient>, IPortfolioClientRepository
    {
        public PortfolioClientRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Client>> GetByPortfolioId(Guid portfolioId)
        {
            return await _context.Clients
                                .Where(e => e.PortfolioClients.Any(p => p.PortfolioId == portfolioId))
                                .Include(c => c.EmailAddresses)
                                .Include(c => c.MobileNumbers)
                                .Include(c => c.ClientCarriers)
                                .Include(c => c.ClientType)
                                .Include(c => c.Country)
                                .Include(c => c.IdDocumentType)
                                .Include(c => c.Gender)
                                .Include(c => c.MaritalStatus)
                                .Include(c => c.Occupation)
                                .Include(c => c.Title)
                                .OrderBy(n => n.LastName).AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetByPortfolioIdAndClientId(Guid portfolioId, Guid clientId)
        {
            return await _context.Clients
                                .Where(e => e.PortfolioClients.Any(p => p.PortfolioId == portfolioId && p.ClientId == clientId))
                                .Include(c => c.EmailAddresses)
                                .Include(c => c.MobileNumbers)
                                .Include(c => c.ClientCarriers)
                                .Include(c => c.ClientType)
                                .Include(c => c.Country)
                                .Include(c => c.IdDocumentType)
                                .Include(c => c.Gender)
                                .Include(c => c.MaritalStatus)
                                .Include(c => c.Occupation)
                                .Include(c => c.Title)
                                .FirstOrDefaultAsync();
        }

        public Task<Client> GetByPortfolioIdAndIdNumber(Guid portfolioId, string idNumber)
        {
            throw new NotImplementedException();
        }
    }
}