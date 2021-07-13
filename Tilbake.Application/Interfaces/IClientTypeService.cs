using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientTypeService
    {
        Task<IEnumerable<ClientTypeResource>> GetAllAsync();
        Task<ClientTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ClientTypeSaveResource resource);
        Task<int> UpdateAsync(ClientTypeResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ClientTypeResource resource);
    }
}