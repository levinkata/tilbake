using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IResidenceTypeService
    {
        Task<IEnumerable<ResidenceTypeResource>> GetAllAsync();
        Task<ResidenceTypeResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ResidenceTypeSaveResource resource);
        Task<int> UpdateAsync(ResidenceTypeResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
