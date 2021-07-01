using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class ClientTypeService : IClientTypeService
    {
        private readonly IClientTypeRepository _clientTypeRepository;
        
        public ClientTypeService(IClientTypeRepository clientTypeRepository)
        {
            _clientTypeRepository = clientTypeRepository ?? throw new ArgumentNullException(nameof(clientTypeRepository));
        }

        public async Task<ClientTypeResponse> AddAsync(ClientType clientType)
        {
            try
            {
                await _clientTypeRepository.AddAsync(clientType).ConfigureAwait(true);
                return new ClientTypeResponse(clientType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientTypeResponse($"An error occurred when saving the clientType: {ex.Message}");
            }
        }

        public async Task<ClientTypeResponse> DeleteAsync(Guid id)
        {
            var existingClientType = await _clientTypeRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingClientType == null)
                return new ClientTypeResponse($"ClientType Id not found: {id}");

            try
            {
                await _clientTypeRepository.DeleteAsync(existingClientType).ConfigureAwait(false);
                return new ClientTypeResponse(existingClientType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientTypeResponse($"An error occurred when deleting the clientType: {ex.Message}");
            }
        }

        public async Task<ClientTypeResponse> DeleteAsync(ClientType clientType)
        {
            if (clientType == null)
                return new ClientTypeResponse($"ClientType not found: {clientType}");

            try
            {
                await _clientTypeRepository.DeleteAsync(clientType).ConfigureAwait(false);
                return new ClientTypeResponse(clientType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientTypeResponse($"An error occurred when deleting the clientType: {ex.Message}");
            }
        }

        public async Task<IEnumerable<ClientType>> GetAllAsync()
        {
            return await Task.Run(() => _clientTypeRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<ClientTypeResponse> GetByIdAsync(Guid id)
        {
            var clientType = await _clientTypeRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (clientType == null)
                return new ClientTypeResponse($"ClientType Id not found: {id}");

            return new ClientTypeResponse(clientType);
        }

        public async Task<ClientTypeResponse> UpdateAsync(Guid id, ClientType clientType)
        {
            if (clientType == null)
                return new ClientTypeResponse($"ClientType not found: {clientType}");

            var existingClientType = await _clientTypeRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingClientType == null)
                return new ClientTypeResponse($"ClientType Id not found: {id}");

            existingClientType.Name = clientType.Name;

            try
            {
                await _clientTypeRepository.UpdateAsync(existingClientType).ConfigureAwait(false);
                return new ClientTypeResponse(existingClientType);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientTypeResponse($"An error occurred when updating the clientType: {ex.Message}");
            }
        }
    }
}