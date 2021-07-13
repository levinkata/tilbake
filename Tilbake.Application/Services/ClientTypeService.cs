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
    public class ClientTypeService : IClientTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ClientTypeSaveResource resource)
        {
            var clientType = _mapper.Map<ClientTypeSaveResource, ClientType>(resource);
            clientType.Id = Guid.NewGuid();

            await _unitOfWork.ClientTypes.AddAsync(clientType).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ClientTypes.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(ClientTypeResource resource)
        {
            var clientType = _mapper.Map<ClientTypeResource, ClientType>(resource);
            await _unitOfWork.ClientTypes.DeleteAsync(clientType).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<ClientTypeResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.ClientTypes.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<ClientType>, IEnumerable<ClientTypeResource>>(result);

            return resources;
        }

        public async Task<ClientTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ClientTypes.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<ClientType, ClientTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ClientTypeResource resource)
        {
            var clientType = _mapper.Map<ClientTypeResource, ClientType>(resource);
            await _unitOfWork.ClientTypes.UpdateAsync(resource.Id, clientType).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
