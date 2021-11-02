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

            _unitOfWork.BodyTypes.Add(bodyType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.BodyTypes.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BodyTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.BodyTypes.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<BodyType>, IEnumerable<BodyTypeResource>>(result);
            return resources;
        }

        public async Task<BodyTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BodyTypes.GetAsync(
                                            r =>r.Id == id,
                                            r => r.OrderBy(n => n.Name));
            var resource = _mapper.Map<BodyType, BodyTypeResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(BodyTypeResource resource)
        {
            var bodyType = _mapper.Map<BodyTypeResource, BodyType>(resource);
            _unitOfWork.BodyTypes.Update(resource.Id, bodyType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
