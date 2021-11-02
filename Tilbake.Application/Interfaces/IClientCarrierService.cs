using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientCarrierService
    {
        Task<IEnumerable<ClientCarrierResource>> GetByClientIdAsync(Guid clientId);
        Task<int> AddAsync(ClientCarrierSaveResource resource);
        Task<int> UpdateAsync(ClientCarrierResource resource);
    }
}
