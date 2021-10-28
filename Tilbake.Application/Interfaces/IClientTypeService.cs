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
        void Add(ClientTypeSaveResource resource);
        void Update(ClientTypeResource resource);
        void Delete(Guid id);
    }
}