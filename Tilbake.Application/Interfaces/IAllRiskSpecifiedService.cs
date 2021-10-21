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
        Task<AllRiskSpecifiedResource> AddAsync(AllRiskSpecifiedSaveResource resource);
        Task<AllRiskSpecifiedResource> UpdateAsync(AllRiskSpecifiedResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(AllRiskSpecifiedResource resource);
    }
}
