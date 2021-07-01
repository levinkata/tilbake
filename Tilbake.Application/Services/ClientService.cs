using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Interfaces;

namespace Tilbake.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        
        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
        }

        public async Task<ClientResponse> AddAsync(Client client)
        {
            try
            {
                await _clientRepository.AddAsync(client).ConfigureAwait(true);
                return new ClientResponse(client);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientResponse($"An error occurred when saving the client: {ex.Message}");
            }
        }

        public async Task<ClientResponse> DeleteAsync(Guid id)
        {
            var existingClient = await _clientRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingClient == null)
                return new ClientResponse($"Client Id not found: {id}");

            try
            {
                await _clientRepository.DeleteAsync(existingClient).ConfigureAwait(false);
                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientResponse($"An error occurred when deleting the client: {ex.Message}");
            }
        }

        public async Task<ClientResponse> DeleteAsync(Client client)
        {
            if (client == null)
                return new ClientResponse($"Client not found: {client}");

            try
            {
                await _clientRepository.DeleteAsync(client).ConfigureAwait(false);
                return new ClientResponse(client);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientResponse($"An error occurred when deleting the client: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Client>> GetAllAsync()
        {
            return await Task.Run(() => _clientRepository.GetAllAsync()).ConfigureAwait(true);
        }

        public async Task<ClientResponse> GetByIdAsync(Guid id)
        {
            var client = await _clientRepository.GetByIdAsync(id).ConfigureAwait(true);
            if (client == null)
                return new ClientResponse($"Client Id not found: {id}");

            return new ClientResponse(client);
        }

        public async Task<ClientResponse> UpdateAsync(Guid id, Client client)
        {
            if (client == null)
                return new ClientResponse($"Client not found: {client}");

            var existingClient = await _clientRepository.GetByIdAsync(id).ConfigureAwait(true);

            if (existingClient == null)
                return new ClientResponse($"Client Id not found: {id}");

            existingClient.TitleId = client.TitleId;
            existingClient.ClientTypeId = client.ClientTypeId;
            existingClient.FirstName = client.FirstName;
            existingClient.MiddleName = client.MiddleName;
            existingClient.LastName = client.LastName;
            existingClient.BirthDate = client.BirthDate;
            existingClient.GenderId = client.GenderId;
            existingClient.IdNumber = client.IdNumber;
            existingClient.MaritalStatusId = client.MaritalStatusId;
            existingClient.CountryId = client.CountryId;
            existingClient.Phone = client.Phone;
            existingClient.Mobile = client.Mobile;
            existingClient.Email = client.Email;
            existingClient.CarrierId = client.CarrierId;
            existingClient.OccupationId = client.OccupationId;            

            try
            {
                await _clientRepository.UpdateAsync(existingClient).ConfigureAwait(false);
                return new ClientResponse(existingClient);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new ClientResponse($"An error occurred when updating the client: {ex.Message}");
            }
        }
    }
}