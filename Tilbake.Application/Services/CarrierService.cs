using AutoMapper;
using Microsoft.AspNetCore.Authentication;
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

        public async void Add(CarrierSaveResource resource)
        {
            var carrier = _mapper.Map<CarrierSaveResource, Carrier>(resource);
            carrier.Id = Guid.NewGuid();
            carrier.DateAdded = DateTime.Now;

            _unitOfWork.Carriers.Add(carrier);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Carriers.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CarrierResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Carriers.GetAllAsync(
                                                    null,
                                                    r => r.OrderBy(p => p.Name));

            var resources = _mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierResource>>(result);
            return resources;
        }

        public async Task<CarrierResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Carriers.GetFirstOrDefaultAsync(
                                                    r => r.Id == id);

            var resource = _mapper.Map<Carrier, CarrierResource>(result);
            return resource;
        }

        public async void Update(CarrierResource resource)
        {
            var carrier = _mapper.Map<CarrierResource, Carrier>(resource);
            carrier.DateModified = DateTime.Now;

            _unitOfWork.Carriers.Update(resource.Id, carrier);
            await _unitOfWork.SaveAsync();
        }
    }
}
