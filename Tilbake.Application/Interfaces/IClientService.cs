using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientResource>> GetAllAsync();
        Task<ClientResource> GetByIdAsync(Guid id);
        Task<ClientResource> GetByIdNumberAsync(string idNumber);
        Task<int> AddAsync(ClientSaveResource resource);
        Task<int> UpdateAsync(ClientResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ClientResource resource);
    }
}