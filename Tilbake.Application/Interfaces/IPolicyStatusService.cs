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
        void Add(PolicyStatusSaveResource resource);
        void Update(PolicyStatusResource resource);
        void Delete(Guid id);
    }
}