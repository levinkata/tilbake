using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRiskItemService
    {
        Task<IEnumerable<RiskItemResource>> GetAllAsync();
        Task<RiskItemResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(RiskItemSaveResource resource);
        Task<int> UpdateAsync(RiskItemResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
