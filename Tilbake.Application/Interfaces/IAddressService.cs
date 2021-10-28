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
        void Add(AddressSaveResource resource);
        void Update(AddressResource resource);
        void Delete(Guid id);
    }
}
