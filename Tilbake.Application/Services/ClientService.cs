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
    public class ClientService : IClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ClientSaveResource resource)
        {
            var client = _mapper.Map<ClientSaveResource, Client>(resource);
            client.Id = Guid.NewGuid();

            await _unitOfWork.Clients.AddAsync(client).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Clients.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(ClientResource resource)
        {
            var client = _mapper.Map<ClientResource, Client>(resource);
            await _unitOfWork.Clients.DeleteAsync(client).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<ClientResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Clients.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.LastName);

            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);

            return resources;
        }

        public async Task<ClientResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Clients.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Client, ClientResource>(result);

            return resources;
        }

        public async Task<ClientResource> GetByIdNumberAsync(string idNumber)
        {
            var result = await _unitOfWork.Clients.GetByIdNumberAsync(idNumber).ConfigureAwait(true);
            var resources = _mapper.Map<Client, ClientResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ClientResource resource)
        {
            var client = _mapper.Map<ClientResource, Client>(resource);
            await _unitOfWork.Clients.UpdateAsync(resource.Id, client).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}