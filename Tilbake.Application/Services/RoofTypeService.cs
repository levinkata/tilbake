﻿using AutoMapper;
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
    public class RoofTypeService : IRoofTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoofTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(RoofTypeSaveResource resource)
        {
            var roofType = _mapper.Map<RoofTypeSaveResource, RoofType>(resource);
            roofType.Id = Guid.NewGuid();

            _unitOfWork.RoofTypes.Add(roofType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.RoofTypes.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RoofTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.RoofTypes.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<RoofType>, IEnumerable<RoofTypeResource>>(result);

            return resources;
        }

        public async Task<RoofTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RoofTypes.GetByIdAsync(id);
            var resource = _mapper.Map<RoofType, RoofTypeResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(RoofTypeResource resource)
        {
            var roofType = _mapper.Map<RoofTypeResource, RoofType>(resource);
            _unitOfWork.RoofTypes.Update(resource.Id, roofType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
