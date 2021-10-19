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
    public class MaritalStatusService : IMaritalStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MaritalStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(MaritalStatusSaveResource resource)
        {
            var maritalStatus = _mapper.Map<MaritalStatusSaveResource, MaritalStatus>(resource);
            maritalStatus.Id = Guid.NewGuid();

            await _unitOfWork.MaritalStatuses.AddAsync(maritalStatus);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.MaritalStatuses.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(MaritalStatusResource resource)
        {
            var maritalStatus = _mapper.Map<MaritalStatusResource, MaritalStatus>(resource);
            await _unitOfWork.MaritalStatuses.DeleteAsync(maritalStatus);

            return await _unitOfWork.SaveAsync();
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

        public async Task<int> UpdateAsync(MaritalStatusResource resource)
        {
            var maritalStatus = _mapper.Map<MaritalStatusResource, MaritalStatus>(resource);
            await _unitOfWork.MaritalStatuses.UpdateAsync(resource.Id, maritalStatus);

            return await _unitOfWork.SaveAsync();
        }
    }
}
