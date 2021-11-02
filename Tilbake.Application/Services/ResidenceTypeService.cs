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

            _unitOfWork.ResidenceTypes.Add(residenceType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.ResidenceTypes.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ResidenceTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ResidenceTypes.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<ResidenceType>, IEnumerable<ResidenceTypeResource>>(result);

            return resources;
        }

        public async Task<ResidenceTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ResidenceTypes.GetByIdAsync(id);
            var resource = _mapper.Map<ResidenceType, ResidenceTypeResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(ResidenceTypeResource resource)
        {
            var residenceType = _mapper.Map<ResidenceTypeResource, ResidenceType>(resource);
            _unitOfWork.ResidenceTypes.Update(resource.Id, residenceType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
