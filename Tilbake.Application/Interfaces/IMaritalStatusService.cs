using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IMaritalStatusService
    {
        Task<IEnumerable<MaritalStatusResource>> GetAllAsync();
        Task<MaritalStatusResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(MaritalStatusSaveResource resource);
        Task<int> UpdateAsync(MaritalStatusResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}