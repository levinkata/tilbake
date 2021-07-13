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
        Task<int> AddAsync(DriverTypeSaveResource resource);
        Task<int> UpdateAsync(DriverTypeResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(DriverTypeResource resource);
    }
}