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
    public class RatingMotorExcessService : IRatingMotorExcessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingMotorExcessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(RatingMotorExcessSaveResource resource)
        {
            var ratingMotorExcess = _mapper.Map<RatingMotorExcessSaveResource, RatingMotorExcess>(resource);
            ratingMotorExcess.Id = Guid.NewGuid();
            ratingMotorExcess.DateAdded = DateTime.Now;

            await _unitOfWork.RatingMotorExcesses.AddAsync(ratingMotorExcess);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.RatingMotorExcesses.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(RatingMotorExcessResource resource)
        {
            var ratingMotorExcess = _mapper.Map<RatingMotorExcessResource, RatingMotorExcess>(resource);
            await _unitOfWork.RatingMotorExcesses.DeleteAsync(ratingMotorExcess);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorExcessResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetFirstOrDefaultAsync(
                                                        r => r.Id == id,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotorExcess, RatingMotorExcessResource>(result);
            return resource;
        }

        public async Task<IEnumerable<RatingMotorExcessResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetAllAsync(
                                            r => r.InsurerId == insurerId,
                                            r => r.OrderBy(p => p.StartValue),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<RatingMotorExcess>, IEnumerable<RatingMotorExcessResource>>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(RatingMotorExcessResource resource)
        {
            var ratingMotorExcess = _mapper.Map<RatingMotorExcessResource, RatingMotorExcess>(resource);
            ratingMotorExcess.DateModified = DateTime.Now;

            await _unitOfWork.RatingMotorExcesses.UpdateAsync(resource.Id, ratingMotorExcess);
            return await _unitOfWork.SaveAsync();
        }
    }
}
