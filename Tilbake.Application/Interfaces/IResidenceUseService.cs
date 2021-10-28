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
        void Add(ResidenceUseSaveResource resource);
        void Update(ResidenceUseResource resource);
        void Delete(Guid id);
    }
}
