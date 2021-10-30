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

        public async void Add(AddressSaveResource resource)
        {
            var address = _mapper.Map<AddressSaveResource, Address>(resource);
            address.DateAdded = DateTime.Now;

            _unitOfWork.Addresses.Add(address);

            await _unitOfWork.SaveAsync();            
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Addresses.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AddressResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Addresses.GetAllAsync(
                                                    null,
                                                    r => r.OrderBy(n => n.PhysicalAddress),
                                                    r => r.City);
            var resources = _mapper.Map<IEnumerable<Address>, IEnumerable<AddressResource>>(result);

            return resources;
        }

        public async Task<AddressResource> GetByClientIdAsync(Guid clientId)
        {
            var result = await _unitOfWork.Addresses.GetFirstOrDefaultAsync(
                                                    r => r.ClientId == clientId,
                                                    r => r.City);

            var resource = _mapper.Map<Address, AddressResource>(result);
            return resource;
        }

        public async Task<AddressResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Addresses.GetFirstOrDefaultAsync(
                                                    r => r.Id == id,
                                                    r => r.City);

            var resource = _mapper.Map<Address, AddressResource>(result);
            return resource;
        }

        public async void Update(AddressResource resource)
        {
            var address = _mapper.Map<AddressResource, Address>(resource);
            address.DateModified = DateTime.Now;

            _unitOfWork.Addresses.Update(resource.Id, address);
            await _unitOfWork.SaveAsync();
        }
    }
}
