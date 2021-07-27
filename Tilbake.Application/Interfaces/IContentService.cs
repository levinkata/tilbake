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
        Task<int> AddAsync(ContentSaveResource resource);
        Task<int> UpdateAsync(ContentResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ContentResource resource);
    }
}
