﻿using AutoMapper;
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
    public class MotorMakeService : IMotorMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotorMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(MotorMakeSaveResource resource)
        {
            var motorMake = _mapper.Map<MotorMakeSaveResource, MotorMake>(resource);
            motorMake.Id = Guid.NewGuid();

            await _unitOfWork.MotorMakes.AddAsync(motorMake);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.MotorMakes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(MotorMakeResource resource)
        {
            var motorMake = _mapper.Map<MotorMakeResource, MotorMake>(resource);
            await _unitOfWork.MotorMakes.DeleteAsync(motorMake);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MotorMakeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.MotorMakes.GetAllAsync();
            result = result.OrderBy(n => n.Name);
            
            var resources = _mapper.Map<IEnumerable<MotorMake>, IEnumerable<MotorMakeResource>>(result);
            
            return resources;
        }

        public async Task<MotorMakeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.MotorMakes.GetByIdAsync(id);
            var resources = _mapper.Map<MotorMake, MotorMakeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(MotorMakeResource resource)
        {
            var motorMake = _mapper.Map<MotorMakeResource, MotorMake>(resource);
            await _unitOfWork.MotorMakes.UpdateAsync(resource.Id, motorMake);

            return await _unitOfWork.SaveAsync();
        }
    }
}
