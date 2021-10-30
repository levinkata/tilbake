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

        public async void Add(BodyTypeSaveResource resource)
        {
            var bodyType = _mapper.Map<BodyTypeSaveResource, BodyType>(resource);
            bodyType.Id = Guid.NewGuid();

            _unitOfWork.BodyTypes.Add(bodyType);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.BodyTypes.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BodyTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.BodyTypes.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<BodyType>, IEnumerable<BodyTypeResource>>(result);
            return resources;
        }

        public async Task<BodyTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.BodyTypes.GetByIdAsync(id);
            var resource = _mapper.Map<BodyType, BodyTypeResource>(result);
            return resource;
        }

        public async void Update(BodyTypeResource resource)
        {
            var bodyType = _mapper.Map<BodyTypeResource, BodyType>(resource);
            _unitOfWork.BodyTypes.Update(resource.Id, bodyType);

            await _unitOfWork.SaveAsync();
        }
    }
}
