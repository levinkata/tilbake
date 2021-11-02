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

            _unitOfWork.ClientTypes.Add(clientType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.ClientTypes.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ClientTypes.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<ClientType>, IEnumerable<ClientTypeResource>>(result);
            return resources;
        }

        public async Task<ClientTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ClientTypes.GetByIdAsync(id);
            var resource = _mapper.Map<ClientType, ClientTypeResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(ClientTypeResource resource)
        {
            var clientType = _mapper.Map<ClientTypeResource, ClientType>(resource);
            _unitOfWork.ClientTypes.Update(resource.Id, clientType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
