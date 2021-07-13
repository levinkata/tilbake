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

            await _unitOfWork.Motors.AddAsync(motor).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Motors.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(MotorResource resource)
        {
            var motor = _mapper.Map<MotorResource, Motor>(resource);
            await _unitOfWork.Motors.DeleteAsync(motor).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<MotorResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Motors.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.RegNumber);

            var resources = _mapper.Map<IEnumerable<Motor>, IEnumerable<MotorResource>>(result);

            return resources;
        }

        public async Task<MotorResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Motors.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Motor, MotorResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(MotorResource resource)
        {
            var motor = _mapper.Map<MotorResource, Motor>(resource);
            await _unitOfWork.Motors.UpdateAsync(resource.Id, motor).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
