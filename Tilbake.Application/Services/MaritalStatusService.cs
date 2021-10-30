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
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaritalStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(MaritalStatusSaveResource resource)
        {
            var maritalStatus = _mapper.Map<MaritalStatusSaveResource, MaritalStatus>(resource);
            maritalStatus.Id = Guid.NewGuid();

            _unitOfWork.MaritalStatuses.Add(maritalStatus);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.MaritalStatuses.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<MaritalStatusResource>> GetAllAsync()
        {
            var result = await _unitOfWork.MaritalStatuses.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<MaritalStatus>, IEnumerable<MaritalStatusResource>>(result);
            return resources;
        }

        public async Task<MaritalStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.MaritalStatuses.GetByIdAsync(id);
            var resource = _mapper.Map<MaritalStatus, MaritalStatusResource>(result);

            return resource;
        }

        public async void Update(MaritalStatusResource resource)
        {
            var maritalStatus = _mapper.Map<MaritalStatusResource, MaritalStatus>(resource);
            _unitOfWork.MaritalStatuses.Update(resource.Id, maritalStatus);

            await _unitOfWork.SaveAsync();
        }
    }
}
