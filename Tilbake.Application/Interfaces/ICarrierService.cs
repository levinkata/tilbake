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
        Task<int> AddAsync(CarrierSaveResource resource);
        Task<int> Update(CarrierResource resource);
        Task<int> Delete(Guid id);
    }
}
