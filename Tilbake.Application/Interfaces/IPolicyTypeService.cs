using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPolicyTypeService
    {
        Task<IEnumerable<PolicyTypeResource>> GetAllAsync();
        Task<PolicyTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PolicyTypeSaveResource resource);
        Task<int> UpdateAsync(PolicyTypeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}