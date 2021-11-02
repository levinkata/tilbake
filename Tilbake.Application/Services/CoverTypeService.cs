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
    public class CoverTypeService : ICoverTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoverTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CoverTypeSaveResource resource)
        {
            var coverType = _mapper.Map<CoverTypeSaveResource, CoverType>(resource);
            coverType.Id = Guid.NewGuid();

            _unitOfWork.CoverTypes.Add(coverType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.CoverTypes.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CoverTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.CoverTypes.GetAsync(
                                        null,
                                        r => r.OrderBy(p => p.Name));

            var resources = _mapper.Map<IEnumerable<CoverType>, IEnumerable<CoverTypeResource>>(result);
            return resources;
        }

        public async Task<CoverTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.CoverTypes.GetByIdAsync(id);
            var resource = _mapper.Map<CoverType, CoverTypeResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(CoverTypeResource resource)
        {
            var coverType = _mapper.Map<CoverTypeResource, CoverType>(resource);
            _unitOfWork.CoverTypes.Update(resource.Id, coverType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
