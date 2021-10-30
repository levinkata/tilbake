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
    public class CoverTypeService : ICoverTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoverTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(CoverTypeSaveResource resource)
        {
            var coverType = _mapper.Map<CoverTypeSaveResource, CoverType>(resource);
            coverType.Id = Guid.NewGuid();

            _unitOfWork.CoverTypes.Add(coverType);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.CoverTypes.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CoverTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.CoverTypes.FindAllAsync(
                                        null,
                                        r => r.OrderBy(p => p.Name));

            var resources = _mapper.Map<IEnumerable<CoverType>, IEnumerable<CoverTypeResource>>(result);
            return resources;
        }

        public async Task<CoverTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.CoverTypes.GetByIdAsync(id);
            var resource = _mapper.Map<CoverType, CoverTypeResource>(result);

            return resource;
        }

        public async void Update(CoverTypeResource resource)
        {
            var coverType = _mapper.Map<CoverTypeResource, CoverType>(resource);
            _unitOfWork.CoverTypes.Update(resource.Id, coverType);

            await _unitOfWork.SaveAsync();
        }
    }
}
