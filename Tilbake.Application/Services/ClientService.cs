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
            await _unitOfWork.Clients.AddAsync(client);

            int ro = resource.CarrierIds.Length;
            var carriers = resource.CarrierIds;
            var clientId = client.Id;
            List<ClientCarrier> clientCarriers = new();

            for (int i = 0; i < ro; i++)
            {
                ClientCarrier clientCarrier = new()
                {
                    ClientId = clientId,
                    CarrierId = Guid.Parse(carriers[i].ToString())
                };
                clientCarriers.Add(clientCarrier);
            }

            await _unitOfWork.ClientCarriers.AddRangeAsync(clientCarriers);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Clients.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(ClientResource resource)
        {
            var client = _mapper.Map<ClientResource, Client>(resource);
            await _unitOfWork.Clients.DeleteAsync(client);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<ClientResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Clients.GetAllAsync());
            result = result.OrderBy(n => n.LastName);

            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);

            return resources;
        }

        public async Task<ClientResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                                    r => r.Id == id,
                                                    r => r.ClientType,
                                                    r => r.Country,
                                                    r => r.Gender,
                                                    r => r.MaritalStatus,
                                                    r => r.Occupation,
                                                    r => r.Title);

            var resources = _mapper.Map<Client, ClientResource>(result);

            return resources;
        }

        public async Task<ClientResource> GetByIdNumberAsync(string idNumber)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                            c => c.IdNumber == idNumber,
                                            c => c.ClientType,
                                            c => c.Country,
                                            c => c.Gender,
                                            c => c.MaritalStatus,
                                            c => c.Occupation,
                                            c => c.Title);

            var resources = _mapper.Map<Client, ClientResource>(result);

            return resources;
        }

        public async Task<IEnumerable<ClientResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await Task.Run(() => _unitOfWork.Clients.GetAllAsync(
                                                        e => e.PortfolioClients.Any(p => p.PortfolioId == portfolioId),
                                                        e => e.OrderBy(r => r.LastName),
                                                        e => e.PortfolioClients
                                                        ));

            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);

            return resources;
        }

        public async Task<ClientResource> GetByClientId(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                                    c => c.PortfolioClients.Any(p => p.PortfolioId == portfolioId && p.ClientId == clientId),
                                                    c => c.PortfolioClients);

            var resource = _mapper.Map<Client, ClientResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(ClientResource resource)
        {
            var client = _mapper.Map<ClientResource, Client>(resource);
            await _unitOfWork.Clients.UpdateAsync(resource.Id, client);
            
            var clientId = client.Id;
            var clientCarriers = await _unitOfWork.ClientCarriers.GetAllAsync(
                                                    r => r.ClientId == clientId);

            if (clientCarriers != null)
            {
                await _unitOfWork.ClientCarriers.DeleteRangeAsync(clientCarriers);
            }

            if(resource.CarrierIds != null)
            {
                int ro = resource.CarrierIds.Length;
                var carriers = resource.CarrierIds;

                List<ClientCarrier> newClientCarriers = new();
                for (int i = 0; i < ro; i++)
                {
                    ClientCarrier clientCarrier = new()
                    {
                        ClientId = clientId,
                        CarrierId = Guid.Parse(carriers[i].ToString())
                    };
                    newClientCarriers.Add(clientCarrier);
                }

                await _unitOfWork.ClientCarriers.AddRangeAsync(newClientCarriers);
            }

            return await _unitOfWork.SaveAsync();
        }

        public async Task<ClientResource> GetByPolicyIdAsync(Guid policyId)
        {
            var result = await _unitOfWork.Clients.GetFirstOrDefaultAsync(
                                        c => c.PortfolioClients.Any(p => p.Policies.Any(r => r.Id == policyId)));

            var resource = _mapper.Map<Client, ClientResource>(result);

            return resource;
        }
    }
}