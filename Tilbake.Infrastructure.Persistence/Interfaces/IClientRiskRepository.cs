using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IClientRiskRepository : IRepository<ClientRisk>
    {
        Task<IEnumerable<ClientRisk>> GetByClientId(Guid clientId);
        Task<Risk> GetByRiskId(Guid clientId, Guid riskId);
    }    
}