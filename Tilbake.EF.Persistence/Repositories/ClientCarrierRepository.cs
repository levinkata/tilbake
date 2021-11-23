using Tilbake.Core.Models;
using Tilbake.EF.Persistence.Context;
using Tilbake.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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