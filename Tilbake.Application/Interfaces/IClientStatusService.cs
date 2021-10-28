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
        void Add(ClientStatusSaveResource resource);
        void Update(ClientStatusResource resource);
        void Delete(Guid id);
    }
}