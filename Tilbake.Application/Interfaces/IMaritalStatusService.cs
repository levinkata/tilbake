using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IMaritalStatusService
    {
        Task<IEnumerable<MaritalStatusResource>> GetAllAsync();
        Task<MaritalStatusResource> GetByIdAsync(Guid id);
        void Add(MaritalStatusSaveResource resource);
        void Update(MaritalStatusResource resource);
        void Delete(Guid id);
    }
}