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
        void Add(ResidenceTypeSaveResource resource);
        void Update(ResidenceTypeResource resource);
        void Delete(Guid id);
    }
}
