using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface ICarrierService
    {
        Task<IEnumerable<CarrierResource>> GetAllAsync();
        Task<CarrierResource> GetByIdAsync(Guid id);
        void Add(CarrierSaveResource resource);
        void Update(CarrierResource resource);
        void Delete(Guid id);
    }
}
