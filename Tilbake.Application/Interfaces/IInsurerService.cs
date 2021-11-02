using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IInsurerService
    {
        Task<IEnumerable<InsurerResource>> GetAllAsync();
        Task<InsurerResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(InsurerSaveResource resource);
        Task<int> UpdateAsync(InsurerResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}