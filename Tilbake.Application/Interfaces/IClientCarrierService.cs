using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientCarrierService
    {
        Task<IEnumerable<ClientCarrierResource>> GetByClientIdAsync(Guid clientId);
        void Add(ClientCarrierSaveResource resource);
        void Update(ClientCarrierResource resource);
    }
}
