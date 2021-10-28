using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ISalesTypeService
    {
        Task<IEnumerable<SalesTypeResource>> GetAllAsync();
        Task<SalesTypeResource> GetByIdAsync(Guid id);
        void Add(SalesTypeSaveResource resource);
        void Update(SalesTypeResource resource);
        void Delete(Guid id);
    }
}