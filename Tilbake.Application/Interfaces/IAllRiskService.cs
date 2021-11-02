using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IAllRiskService
    {
        Task<IEnumerable<AllRiskResource>> GetAllAsync();
        Task<AllRiskResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(AllRiskSaveResource resource);
        Task<int> UpdateAsync(AllRiskResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
