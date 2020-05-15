using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IPolitikkTypeRepository
    {
        Task<IEnumerable<PolitikkType>> GetAllAsync();
        Task<PolitikkType> GetAsync(Guid id);
        Task<int> AddAsync(PolitikkType politikkType);
        Task<int> UpdateAsync(PolitikkType politikkType);
        Task<int> DeleteAsync(Guid id);
    }
}
