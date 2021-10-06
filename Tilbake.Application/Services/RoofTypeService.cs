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

            await _unitOfWork.RoofTypes.AddAsync(roofType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.RoofTypes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(RoofTypeResource resource)
        {
            var roofType = _mapper.Map<RoofTypeResource, RoofType>(resource);
            await _unitOfWork.RoofTypes.DeleteAsync(roofType);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RoofTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.RoofTypes.GetAllAsync();
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<RoofType>, IEnumerable<RoofTypeResource>>(result);

            return resources;
        }

        public async Task<RoofTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RoofTypes.GetByIdAsync(id);
            var resources = _mapper.Map<RoofType, RoofTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(RoofTypeResource resource)
        {
            var roofType = _mapper.Map<RoofTypeResource, RoofType>(resource);
            await _unitOfWork.RoofTypes.UpdateAsync(resource.Id, roofType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
