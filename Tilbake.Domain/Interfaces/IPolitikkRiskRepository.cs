using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IPolitikkRiskRepository
    {
        Task<IEnumerable<PolitikkRisk>> GetAllAsync(Guid politikkId);
        Task<PolitikkRisk> GetAsync(Guid id);
        Task<int> AddAsync(PolitikkRisk politikkRisk);
        Task<int> UpdateAsync(PolitikkRisk politikkRisk);
        Task<int> DeleteAsync(Guid id);
    }
}