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
    public class CoverTypeService : ICoverTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoverTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(CoverTypeSaveResource resource)
        {
            var coverType = _mapper.Map<CoverTypeSaveResource, CoverType>(resource);
            coverType.Id = Guid.NewGuid();

            await _unitOfWork.CoverTypes.AddAsync(coverType);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.CoverTypes.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(CoverTypeResource resource)
        {
            var coverType = _mapper.Map<CoverTypeResource, CoverType>(resource);
            await _unitOfWork.CoverTypes.DeleteAsync(coverType);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<CoverTypeResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.CoverTypes.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<CoverType>, IEnumerable<CoverTypeResource>>(result);

            return resources;
        }

        public async Task<CoverTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.CoverTypes.GetByIdAsync(id);
            var resources = _mapper.Map<CoverType, CoverTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(CoverTypeResource resource)
        {
            var coverType = _mapper.Map<CoverTypeResource, CoverType>(resource);
            await _unitOfWork.CoverTypes.UpdateAsync(resource.Id, coverType);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
