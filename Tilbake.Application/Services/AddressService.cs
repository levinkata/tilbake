using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

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

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Addresses.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(AddressResource resource)
        {
            var address = _mapper.Map<AddressResource, Address>(resource);
            await _unitOfWork.Addresses.DeleteAsync(address);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AddressResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Addresses.GetAllAsync();
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
            var result = await _unitOfWork.Addresses.GetFirstOrDefaultAsync(r => r.Id == id);
            var resource = _mapper.Map<Address, AddressResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(AddressResource resource)
        {
            var address = _mapper.Map<AddressResource, Address>(resource);
            await _unitOfWork.Addresses.UpdateAsync(resource.Id, address);

            return await _unitOfWork.SaveAsync();
        }
    }
}
