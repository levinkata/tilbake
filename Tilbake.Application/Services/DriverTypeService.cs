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
    public class DriverTypeService : IDriverTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(DriverTypeSaveResource resource)
        {
            var driverType = _mapper.Map<DriverTypeSaveResource, DriverType>(resource);
            driverType.Id = Guid.NewGuid();

            _unitOfWork.DriverTypes.Add(driverType);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.DriverTypes.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DriverTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.DriverTypes.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<DriverType>, IEnumerable<DriverTypeResource>>(result);
            return resources;
        }

        public async Task<DriverTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.DriverTypes.GetByIdAsync(id);
            var resource = _mapper.Map<DriverType, DriverTypeResource>(result);
            return resource;
        }

        public async void Update(DriverTypeResource resource)
        {
            var driverType = _mapper.Map<DriverTypeResource, DriverType>(resource);
            _unitOfWork.DriverTypes.Update(resource.Id, driverType);

            _unitOfWork.SaveAsync();
        }
    }
}
