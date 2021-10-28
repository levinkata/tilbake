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
        void Add(BodyTypeSaveResource resource);
        void Update(BodyTypeResource resource);
        void Delete(Guid id);
    }
}