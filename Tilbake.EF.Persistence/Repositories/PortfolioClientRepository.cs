using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core.Context;
using Tilbake.Core.Interfaces;
using Tilbake.Core.Models;

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
                                .Where(e => e.PortfolioClients.Any(p => p.PortfolioId == portfolioId))
                                .OrderBy(n => n.LastName)
                                .AsSplitQuery().AsNoTracking().ToListAsync();
        }

        public async Task<Client> GetByPortfolioIdAndClientId(Guid portfolioId, Guid clientId)
        {
            return await _context.Clients
                                .Where(e => e.PortfolioClients.Any(p => p.PortfolioId == portfolioId && p.ClientId == clientId))
                                .Include(c => c.Addresses)
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