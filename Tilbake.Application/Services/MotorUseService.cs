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
    public class MotorUseService : IMotorUseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotorUseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(MotorUseSaveResource resource)
        {
            var motorUse = _mapper.Map<MotorUseSaveResource, MotorUse>(resource);
            motorUse.Id = Guid.NewGuid();

            await _unitOfWork.MotorUses.AddAsync(motorUse);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.MotorUses.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(MotorUseResource resource)
        {
            var motorUse = _mapper.Map<MotorUseResource, MotorUse>(resource);
            await _unitOfWork.MotorUses.DeleteAsync(motorUse);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MotorUseResource>> GetAllAsync()
        {
            var result = await _unitOfWork.MotorUses.GetAllAsync();
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<MotorUse>, IEnumerable<MotorUseResource>>(result);

            return resources;
        }

        public async Task<MotorUseResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.MotorUses.GetByIdAsync(id);
            var resources = _mapper.Map<MotorUse, MotorUseResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(MotorUseResource resource)
        {
            var motorUse = _mapper.Map<MotorUseResource, MotorUse>(resource);
            await _unitOfWork.MotorUses.UpdateAsync(resource.Id, motorUse);

            return await _unitOfWork.SaveAsync();
        }
    }
}
