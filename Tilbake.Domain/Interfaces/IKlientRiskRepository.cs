using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKlientRiskRepository
    {
        Task<IEnumerable<KlientRisk>> GetAllAsync();
        Task<IEnumerable<KlientRisk>> GetKlientRisks(Guid klientId);
        Task<KlientRisk> GetAsync(Guid id);
        Task<int> DeleteAsync(Guid id);
    }
}
