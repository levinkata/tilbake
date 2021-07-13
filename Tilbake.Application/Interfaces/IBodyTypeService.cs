using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IBodyTypeService
    {
        Task<IEnumerable<BodyTypeResource>> GetAllAsync();
        Task<BodyTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(BodyTypeSaveResource resource);
        Task<int> UpdateAsync(BodyTypeResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(BodyTypeResource resource);
    }
}