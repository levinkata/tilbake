using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ITaxService
    {
        Task<IEnumerable<TaxResource>> GetAllAsync();
        Task<TaxResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(TaxSaveResource resource);
        Task<int> UpdateAsync(TaxResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}