using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddressService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AddressSaveResource resource)
        {
            var address = _mapper.Map<AddressSaveResource, Address>(resource);
            address.DateAdded = DateTime.Now;

            _unitOfWork.Addresses.Add(address);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Addresses.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AddressResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Addresses.GetAsync(
                                                    null,
                                                    r => r.OrderBy(n => n.PhysicalAddress),
                                                    r => r.City);
            var resources = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(result);
            return resources;
        }

        public async Task<AddressResource> GetByClientIdAsync(Guid clientId)
        {
            var result = await _unitOfWork.Addresses.GetAsync(
                                                    r => r.ClientId == clientId,
                                                    r => r.OrderBy(n => n.City.Name),
                                                    r => r.City);

            var resource = _mapper.Map<Address, AddressResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<AddressResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Addresses.GetAsync(
                                                    r => r.Id == id,
                                                    r => r.OrderBy(n => n.City.Name),
                                                    r => r.City);

            var resource = _mapper.Map<Address, AddressResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(AddressResource resource)
        {
            var address = _mapper.Map<AddressResource, Address>(resource);
            address.DateModified = DateTime.Now;

            _unitOfWork.Addresses.Update(resource.Id, address);
            return await _unitOfWork.SaveAsync();
        }
    }
}
