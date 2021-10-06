using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientStatusService
    {
        Task<IEnumerable<ClientStatusResource>> GetAllAsync();
        Task<ClientStatusResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ClientStatusSaveResource resource);
        Task<int> UpdateAsync(ClientStatusResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ClientStatusResource resource);
    }
}