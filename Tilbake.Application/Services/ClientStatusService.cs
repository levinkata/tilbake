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

        public async void Add(ClientStatusSaveResource resource)
        {
            var clientStatus = _mapper.Map<ClientStatusSaveResource, ClientStatus>(resource);
            clientStatus.Id = Guid.NewGuid();

            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.ClientStatuses.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientStatusResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ClientStatuses.GetAllAsync(
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

        public async void Update(ClientStatusResource resource)
        {
            var clientStatus = _mapper.Map<ClientStatusResource, ClientStatus>(resource);
            _unitOfWork.ClientStatuses.Update(resource.Id, clientStatus);

            await _unitOfWork.SaveAsync();
        }
    }
}
