using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IPolicyTypeService
    {
        Task<IEnumerable<PolicyTypeResource>> GetAllAsync();
        Task<PolicyTypeResource> GetByIdAsync(Guid id);
        void Add(PolicyTypeSaveResource resource);
        void Update(PolicyTypeResource resource);
        void Delete(Guid id);
    }
}