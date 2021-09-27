using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<AddressResource>> GetAllAsync();
        Task<AddressResource> GetByIdAsync(Guid id);
        Task<AddressResource> GetByClientIdAsync(Guid clientId);
        Task<int> AddAsync(AddressSaveResource resource);
        Task<int> UpdateAsync(AddressResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(AddressResource resource);
    }
}
