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
    public class WallTypeService : IWallTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WallTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(WallTypeSaveResource resource)
        {
            var wallType = _mapper.Map<WallTypeSaveResource, WallType>(resource);
            wallType.Id = Guid.NewGuid();

            _unitOfWork.WallTypes.Add(wallType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.WallTypes.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<WallTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.WallTypes.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<WallType>, IEnumerable<WallTypeResource>>(result);

            return resources;
        }

        public async Task<WallTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.WallTypes.GetByIdAsync(id);
            var resource = _mapper.Map<WallType, WallTypeResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(WallTypeResource resource)
        {
            var wallType = _mapper.Map<WallTypeResource, WallType>(resource);
            _unitOfWork.WallTypes.Update(resource.Id, wallType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
