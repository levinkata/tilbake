using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IWallTypeService
    {
        Task<IEnumerable<WallTypeResource>> GetAllAsync();
        Task<WallTypeResource> GetByIdAsync(Guid id);
        void Add(WallTypeSaveResource resource);
        void Update(WallTypeResource resource);
        void Delete(Guid id);
    }
}
