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
    public class PortfolioClientService : IPortfolioClientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PortfolioClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddClientAsync(ClientSaveResource resource)
        {
            var client = _mapper.Map<ClientSaveResource, Client>(resource);
            // var clientNumber = await _unitOfWork.ClientNumberGenerators.NextValue();

            client.Id = Guid.NewGuid();
            client.DateAdded = DateTime.Now;
            //client.ClientNumber = clientNumber;
            await _unitOfWork.Clients.AddAsync(client);
            var clientId = client.Id;

            //int ro = resource.CarrierIds.Length;
            //var carriers = resource.CarrierIds;

            //List<ClientCarrier> clientCarriers = new();

            //for (int i = 0; i < ro; i++)
            //{
            //    ClientCarrier clientCarrier = new()
            //    {
            //        ClientId = clientId,
            //        CarrierId = Guid.Parse(carriers[i].ToString())
            //    };
            //    clientCarriers.Add(clientCarrier);
            //}
            //await _unitOfWork.ClientCarriers.AddRangeAsync(clientCarriers);

            PortfolioClient portfolioClient = new()
            {
                Id = Guid.NewGuid(),
                PortfolioId = resource.PortfolioId,
                ClientId = clientId
            };
            await _unitOfWork.PortfolioClients.AddAsync(portfolioClient);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PortfolioClients.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<bool> ExistsAsync(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetAllAsync(
                                                            e => e.PortfolioId == portfolioId &&
                                                            e.ClientId == clientId);
            
            return result.Any();
        }

        public async Task<PortfolioClientResource> FindAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioClients.GetAllAsync(p => p.Id == id);
            var resource = _mapper.Map<PortfolioClient, PortfolioClientResource>(result.FirstOrDefault());

            return resource;
        }

        public async Task<PortfolioClientResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioClients.GetByIdAsync(id);
            var resource = _mapper.Map<PortfolioClient, PortfolioClientResource>(result);

            return resource;
        }

        public async Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetFirstOrDefaultAsync(
                                e => e.PortfolioId == portfolioId && e.ClientId == clientId);

            return result.Id;
        }
    }
}
