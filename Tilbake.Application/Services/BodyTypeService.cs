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
    public class BodyTypeService : IBodyTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BodyTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(BodyTypeSaveResource resource)
        {
            var bodyType = _mapper.Map<BodyTypeSaveResource, BodyType>(resource);
            bodyType.Id = Guid.NewGuid();

            await _unitOfWork.BodyTypes.AddAsync(bodyType).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.BodyTypes.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(BodyTypeResource resource)
        {
            var bodyType = _mapper.Map<BodyTypeResource, BodyType>(resource);
            await _unitOfWork.BodyTypes.DeleteAsync(bodyType).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<BodyTypeResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.BodyTypes.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<BodyType>, IEnumerable<BodyTypeResource>>(result);

            return resources;
        }

        public async Task<BodyTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BodyTypes.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<BodyType, BodyTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(BodyTypeResource resource)
        {
            var bodyType = _mapper.Map<BodyTypeResource, BodyType>(resource);
            await _unitOfWork.BodyTypes.UpdateAsync(resource.Id, bodyType).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
