using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPolicyStatusService
    {
        Task<IEnumerable<PolicyStatusResource>> GetAllAsync();
        Task<PolicyStatusResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(PolicyStatusSaveResource resource);
        Task<int> UpdateAsync(PolicyStatusResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}