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
    public class ResidenceUseService : IResidenceUseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResidenceUseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(ResidenceUseSaveResource resource)
        {
            var residenceUse = _mapper.Map<ResidenceUseSaveResource, ResidenceUse>(resource);
            residenceUse.Id = Guid.NewGuid();

            _unitOfWork.ResidenceUses.Add(residenceUse);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.ResidenceUses.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ResidenceUseResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ResidenceUses.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<ResidenceUse>, IEnumerable<ResidenceUseResource>>(result);

            return resources;
        }

        public async Task<ResidenceUseResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ResidenceUses.GetByIdAsync(id);
            var resource = _mapper.Map<ResidenceUse, ResidenceUseResource>(result);

            return resource;
        }

        public async void Update(ResidenceUseResource resource)
        {
            var residenceUse = _mapper.Map<ResidenceUseResource, ResidenceUse>(resource);
            _unitOfWork.ResidenceUses.Update(resource.Id, residenceUse);

            await _unitOfWork.SaveAsync();
        }
    }
}
