using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces.UnitOfWork;

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

            await _unitOfWork.Carriers.AddAsync(carrier).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Carriers.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(CarrierResource resource)
        {
            var carrier = _mapper.Map<CarrierResource, Carrier>(resource);
            await _unitOfWork.Carriers.DeleteAsync(carrier).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<CarrierResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Carriers.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierResource>>(result);

            return resources;
        }

        public async Task<CarrierResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Carriers.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Carrier, CarrierResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(CarrierResource resource)
        {
            var carrier = _mapper.Map<CarrierResource, Carrier>(resource);
            await _unitOfWork.Carriers.UpdateAsync(resource.Id, carrier).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
