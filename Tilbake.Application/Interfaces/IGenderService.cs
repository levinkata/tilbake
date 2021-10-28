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
        void Add(GenderSaveResource resource);
        void Update(GenderResource resource);
        void Delete(Guid id);
    }
}