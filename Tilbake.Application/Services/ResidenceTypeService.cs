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
    public class ResidenceTypeService : IResidenceTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResidenceTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ResidenceTypeSaveResource resource)
        {
            var residenceType = _mapper.Map<ResidenceTypeSaveResource, ResidenceType>(resource);
            residenceType.Id = Guid.NewGuid();

            await _unitOfWork.ResidenceTypes.AddAsync(residenceType).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ResidenceTypes.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(ResidenceTypeResource resource)
        {
            var residenceType = _mapper.Map<ResidenceTypeResource, ResidenceType>(resource);
            await _unitOfWork.ResidenceTypes.DeleteAsync(residenceType).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<ResidenceTypeResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.ResidenceTypes.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<ResidenceType>, IEnumerable<ResidenceTypeResource>>(result);

            return resources;
        }

        public async Task<ResidenceTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ResidenceTypes.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<ResidenceType, ResidenceTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ResidenceTypeResource resource)
        {
            var residenceType = _mapper.Map<ResidenceTypeResource, ResidenceType>(resource);
            await _unitOfWork.ResidenceTypes.UpdateAsync(resource.Id, residenceType).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
