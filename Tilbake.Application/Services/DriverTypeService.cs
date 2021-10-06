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
    public class DriverTypeService : IDriverTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DriverTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(DriverTypeSaveResource resource)
        {
            var driverType = _mapper.Map<DriverTypeSaveResource, DriverType>(resource);
            driverType.Id = Guid.NewGuid();

            await _unitOfWork.DriverTypes.AddAsync(driverType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.DriverTypes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(DriverTypeResource resource)
        {
            var driverType = _mapper.Map<DriverTypeResource, DriverType>(resource);
            await _unitOfWork.DriverTypes.DeleteAsync(driverType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DriverTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.DriverTypes.GetAllAsync();
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<DriverType>, IEnumerable<DriverTypeResource>>(result);

            return resources;
        }

        public async Task<DriverTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.DriverTypes.GetByIdAsync(id);
            var resources = _mapper.Map<DriverType, DriverTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(DriverTypeResource resource)
        {
            var driverType = _mapper.Map<DriverTypeResource, DriverType>(resource);
            await _unitOfWork.DriverTypes.UpdateAsync(resource.Id, driverType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
