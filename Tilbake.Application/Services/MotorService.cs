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

            await _unitOfWork.Motors.AddAsync(motor);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Motors.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(MotorResource resource)
        {
            var motor = _mapper.Map<MotorResource, Motor>(resource);
            await _unitOfWork.Motors.DeleteAsync(motor);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MotorResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Motors.GetAllAsync(
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
            await _unitOfWork.Motors.UpdateAsync(resource.Id, motor);

            return await _unitOfWork.SaveAsync();
        }
    }
}
