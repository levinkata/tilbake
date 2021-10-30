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
    public class MotorMakeService : IMotorMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotorMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(MotorMakeSaveResource resource)
        {
            var motorMake = _mapper.Map<MotorMakeSaveResource, MotorMake>(resource);
            motorMake.Id = Guid.NewGuid();

            _unitOfWork.MotorMakes.Add(motorMake);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.MotorMakes.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MotorMakeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.MotorMakes.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));
            
            var resources = _mapper.Map<IEnumerable<MotorMake>, IEnumerable<MotorMakeResource>>(result);
            return resources;
        }

        public async Task<MotorMakeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.MotorMakes.GetByIdAsync(id);
            var resource = _mapper.Map<MotorMake, MotorMakeResource>(result);
            return resource;
        }

        public async void Update(MotorMakeResource resource)
        {
            var motorMake = _mapper.Map<MotorMakeResource, MotorMake>(resource);
            _unitOfWork.MotorMakes.Update(resource.Id, motorMake);

            await _unitOfWork.SaveAsync();
        }
    }
}
