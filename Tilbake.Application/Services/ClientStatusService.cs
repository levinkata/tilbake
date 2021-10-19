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

            await _unitOfWork.ClientStatuses.AddAsync(clientStatus);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ClientStatuses.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(ClientStatusResource resource)
        {
            var clientStatus = _mapper.Map<ClientStatusResource, ClientStatus>(resource);
            await _unitOfWork.ClientStatuses.DeleteAsync(clientStatus);

            return await _unitOfWork.SaveAsync();
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
            var resources = _mapper.Map<ClientStatus, ClientStatusResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ClientStatusResource resource)
        {
            var clientStatus = _mapper.Map<ClientStatusResource, ClientStatus>(resource);
            await _unitOfWork.ClientStatuses.UpdateAsync(resource.Id, clientStatus);

            return await _unitOfWork.SaveAsync();
        }
    }
}
