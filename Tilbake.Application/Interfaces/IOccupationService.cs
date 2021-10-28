using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IOccupationService
    {
        Task<IEnumerable<OccupationResource>> GetAllAsync();
        Task<OccupationResource> GetByIdAsync(Guid id);
        void Add(OccupationSaveResource resource);
        void Update(OccupationResource resource);
        void Delete(Guid id);
    }
}