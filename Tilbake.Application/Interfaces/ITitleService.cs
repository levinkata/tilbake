using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ITitleService
    {
        Task<IEnumerable<TitleResource>> GetAllAsync();
        Task<TitleResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(TitleSaveResource resource);
        Task<int> UpdateAsync(TitleResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(TitleResource resource);
    }
}