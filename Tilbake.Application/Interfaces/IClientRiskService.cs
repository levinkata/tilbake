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
        void Add(ClientRiskSaveResource resource);
        void Update(ClientRiskResource resource);
        void Delete(Guid id);
    }
}