using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface ICarrierService
    {
        Task<IEnumerable<Carrier>> GetAllAsync();
        Task<CarrierResponse> GetByIdAsync(Guid id);
        Task<CarrierResponse> AddAsync(Carrier carrier);
        Task<CarrierResponse> UpdateAsync(Guid id, Carrier carrier);
        Task<CarrierResponse> DeleteAsync(Guid id);
        Task<CarrierResponse> DeleteAsync(Carrier carrier);
    }
}