using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core;
using Tilbake.Core.Models;

namespace Tilbake.Application.Services
{
    public class CarrierService : ICarrierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarrierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CarrierSaveResource resource)
        {
            var carrier = _mapper.Map<CarrierSaveResource, Carrier>(resource);
            carrier.Id = Guid.NewGuid();
            carrier.DateAdded = DateTime.Now;

            _unitOfWork.Carriers.Add(carrier);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Carriers.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CarrierResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Carriers.GetAsync();

            var resources = _mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierResource>>(result);
            return resources;
        }

        public async Task<CarrierResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Carriers.GetByIdAsync(id);

            var resource = _mapper.Map<Carrier, CarrierResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(CarrierResource resource)
        {
            var carrier = _mapper.Map<CarrierResource, Carrier>(resource);
            carrier.DateModified = DateTime.Now;

            _unitOfWork.Carriers.Update(resource.Id, carrier);
            return await _unitOfWork.SaveAsync();
        }
    }
}
