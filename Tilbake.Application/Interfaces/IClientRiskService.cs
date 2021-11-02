using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IClientRiskService
    {
        Task<IEnumerable<ClientRiskResource>> GetAllAsync();
        Task<ClientRiskResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ClientRiskSaveResource resource);
        Task<int> UpdateAsync(ClientRiskResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}