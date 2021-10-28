using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ICoverTypeService
    {
        Task<IEnumerable<CoverTypeResource>> GetAllAsync();
        Task<CoverTypeResource> GetByIdAsync(Guid id);
        void Add(CoverTypeSaveResource resource);
        void Update(CoverTypeResource resource);
        void Delete(Guid id);
    }
}