using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IPolitikkStatusRepository
    {
        Task<IEnumerable<PolitikkStatus>> GetAllAsync();
        Task<PolitikkStatus> GetAsync(Guid id);
        Task<int> AddAsync(PolitikkStatus politikkStatus);
        Task<int> UpdateAsync(PolitikkStatus politikkStatus);
        Task<int> DeleteAsync(Guid id);
    }
}
