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
    public class ClientRiskRepository : Repository<ClientRisk>, IClientRiskRepository
    {
        public ClientRiskRepository(TilbakeDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<ClientRisk>> GetByClientId(Guid clientId)
        {
            return await Task.Run(() => _context.ClientRisks
                                                .Include(c => c.Client)
                                                .Include(p => p.Risk)
                                                .Where(e => e.ClientId == clientId)
                                                .AsNoTracking()).ConfigureAwait(true);
        }

        public async Task<Risk> GetByRiskId(Guid clientId, Guid riskId)
        {
            return await Task.Run(() => _context.Risks
                                                .Where(c => c.ClientRisks
                                                .Any(p => p.ClientId == clientId && p.RiskId == riskId))
                                                .Include(c => c.ClientRisks)
                                                .FirstOrDefaultAsync()).ConfigureAwait(true);
        }
    }
}