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
    public class SalesTypeService : ISalesTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SalesTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(SalesTypeSaveResource resource)
        {
            var salesType = _mapper.Map<SalesTypeSaveResource, SalesType>(resource);
            salesType.Id = Guid.NewGuid();

            await _unitOfWork.SalesTypes.AddAsync(salesType);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.SalesTypes.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(SalesTypeResource resource)
        {
            var salesType = _mapper.Map<SalesTypeResource, SalesType>(resource);
            await _unitOfWork.SalesTypes.DeleteAsync(salesType);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<SalesTypeResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.SalesTypes.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<SalesType>, IEnumerable<SalesTypeResource>>(result);

            return resources;
        }

        public async Task<SalesTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.SalesTypes.GetByIdAsync(id);
            var resources = _mapper.Map<SalesType, SalesTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(SalesTypeResource resource)
        {
            var salesType = _mapper.Map<SalesTypeResource, SalesType>(resource);
            await _unitOfWork.SalesTypes.UpdateAsync(resource.Id, salesType);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
