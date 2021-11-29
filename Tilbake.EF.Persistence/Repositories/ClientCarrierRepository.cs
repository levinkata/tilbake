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
    public class ClientCarrierRepository : Repository<ClientCarrier>, IClientCarrierRepository
    {
        public ClientCarrierRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ClientCarrier>> GetByClientId(Guid clientId)
        {
            return await _context.ClientCarriers
                                .Where(r => r.ClientId == clientId)
                                .Include(r => r.Carrier).AsNoTracking().ToListAsync();
        }
    }
}