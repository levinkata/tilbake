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
        Task<CarrierResource> AddAsync(CarrierSaveResource resource);
        Task<CarrierResource> UpdateAsync(CarrierResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(CarrierResource resource);
    }
}
