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
    public class ClientStatusService : IClientStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientStatusService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ClientStatusSaveResource resource)
        {
            var clientStatus = _mapper.Map<ClientStatusSaveResource, ClientStatus>(resource);
            clientStatus.Id = Guid.NewGuid();

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.ClientStatuses.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientStatusResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ClientStatuses.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<ClientStatus>, IEnumerable<ClientStatusResource>>(result);
            return resources;
        }

        public async Task<ClientStatusResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ClientStatuses.GetByIdAsync(id);
            var resource = _mapper.Map<ClientStatus, ClientStatusResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(ClientStatusResource resource)
        {
            var clientStatus = _mapper.Map<ClientStatusResource, ClientStatus>(resource);
            _unitOfWork.ClientStatuses.Update(resource.Id, clientStatus);

            return await _unitOfWork.SaveAsync();
        }
    }
}
