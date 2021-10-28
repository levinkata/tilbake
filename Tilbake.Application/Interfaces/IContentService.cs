using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IContentService
    {
        Task<IEnumerable<ContentResource>> GetAllAsync();
        Task<ContentResource> GetByIdAsync(Guid id);
        void Add(ContentSaveResource resource);
        void Update(ContentResource resource);
        void Delete(Guid id);
    }
}
