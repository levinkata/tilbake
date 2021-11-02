using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IAllRiskSpecifiedService
    {
        Task<IEnumerable<AllRiskSpecifiedResource>> GetAllAsync();
        Task<AllRiskSpecifiedResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(AllRiskSpecifiedSaveResource resource);
        Task<int> UpdateAsync(AllRiskSpecifiedResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
