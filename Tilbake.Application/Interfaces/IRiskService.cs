using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRiskService
    {
        Task<IEnumerable<RiskResource>> GetAllAsync();
        Task<RiskResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(RiskSaveResource resource);
        Task<int> UpdateAsync(RiskResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(RiskResource resource);
    }
}