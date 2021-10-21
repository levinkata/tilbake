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
        Task<AllRiskResource> AddAsync(AllRiskSaveResource resource);
        Task<AllRiskResource> UpdateAsync(AllRiskResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(AllRiskResource resource);
    }
}
