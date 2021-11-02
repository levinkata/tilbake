using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<GenderResource>> GetAllAsync();
        Task<GenderResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(GenderSaveResource resource);
        Task<int> UpdateAsync(GenderResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}