using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IAllRiskRepository
    {
        Task<IEnumerable<AllRisk>> GetAllAsync();
        Task<AllRisk> GetAsync(Guid id);
        Task<int> AddAsync(Guid klientId, AllRisk allRisk);
        Task<int> UpdateAsync(AllRisk allRisk);
        Task<int> DeleteAsync(Guid id);
    }
}
