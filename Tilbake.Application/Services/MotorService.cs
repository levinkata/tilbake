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
    public class MotorService : IMotorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(MotorSaveResource resource)
        {
            var motor = _mapper.Map<MotorSaveResource, Motor>(resource);
            motor.Id = Guid.NewGuid();

            _unitOfWork.Motors.Add(motor);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Motors.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MotorResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Motors.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.RegNumber));

            var resources = _mapper.Map<IEnumerable<Motor>, IEnumerable<MotorResource>>(result);
            return resources;
        }

        public async Task<MotorResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Motors.GetByIdAsync(id);
            var resource = _mapper.Map<Motor, MotorResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(MotorResource resource)
        {
            var motor = _mapper.Map<MotorResource, Motor>(resource);
            _unitOfWork.Motors.Update(resource.Id, motor);

            return await _unitOfWork.SaveAsync();
        }
    }
}
