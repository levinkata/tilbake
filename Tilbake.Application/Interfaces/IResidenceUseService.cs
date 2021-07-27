using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IResidenceUseService
    {
        Task<IEnumerable<ResidenceUseResource>> GetAllAsync();
        Task<ResidenceUseResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(ResidenceUseSaveResource resource);
        Task<int> UpdateAsync(ResidenceUseResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(ResidenceUseResource resource);
    }
}
