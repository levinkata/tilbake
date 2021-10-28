using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IRoofTypeService
    {
        Task<IEnumerable<RoofTypeResource>> GetAllAsync();
        Task<RoofTypeResource> GetByIdAsync(Guid id);
        void Add(RoofTypeSaveResource resource);
        void Update(RoofTypeResource resource);
        void Delete(Guid id);
    }
}
