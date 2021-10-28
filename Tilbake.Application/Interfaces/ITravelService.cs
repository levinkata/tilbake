using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ITravelService
    {
        Task<IEnumerable<TravelResource>> GetAllAsync();
        Task<TravelResource> GetByIdAsync(Guid id);
        void Add(TravelSaveResource resource);
        void Update(TravelResource resource);
        void Delete(Guid id);
    }
}