using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IDriverTypeService
    {
        Task<IEnumerable<DriverTypeResource>> GetAllAsync();
        Task<DriverTypeResource> GetByIdAsync(Guid id);
        void Add(DriverTypeSaveResource resource);
        void Update(DriverTypeResource resource);
        void Delete(Guid id);
    }
}