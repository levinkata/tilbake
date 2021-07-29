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
    public class ClientDocumentRepository : Repository<ClientDocument>, IClientDocumentRepository
    {
        public ClientDocumentRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ClientDocument>> GetByClientIdAsync(Guid clientId)
        {
            return await Task.Run(() => _context.ClientDocuments
                                                .Include(b => b.DocumentType)
                                                .Include(c => c.Client)
                                                .Where(e => e.ClientId == clientId)
                                                .OrderBy(n => n.Name)
                                                .AsNoTracking());
        }
    }
}
