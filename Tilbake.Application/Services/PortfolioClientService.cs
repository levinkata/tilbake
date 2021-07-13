using AutoMapper;
using System;
using System.Collections.Generic;
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

        public async Task<int> AddAsync(PortfolioClientSaveResource resource)
        {
            var portfolioClient = _mapper.Map<PortfolioClientSaveResource, PortfolioClient>(resource);
            portfolioClient.Id = Guid.NewGuid();

            await _unitOfWork.PortfolioClients.AddAsync(portfolioClient).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> AddClientAsync(ClientSaveResource resource)
        {
            var client = _mapper.Map<ClientSaveResource, Client>(resource);
            client.Id = Guid.NewGuid();

            await _unitOfWork.PortfolioClients.AddClientAsync(resource.PortfolioId, client).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PortfolioClients.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<bool> ExistsAsync(Guid portfolioId, Guid clientId)
        {
            return await _unitOfWork.PortfolioClients.ExistsAsync(portfolioId, clientId).ConfigureAwait(true);
        }

        public async Task<ClientResource> GetByClientId(Guid portfolioId, Guid clientId)
        {
            var result = await Task.Run(() => _unitOfWork.PortfolioClients.GetByClientId(portfolioId, clientId)).ConfigureAwait(true);
            var resource = _mapper.Map<Client, ClientResource>(result);

            return resource;
        }

        public async Task<PortfolioClientResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioClients.GetByIdAsync(id).ConfigureAwait(true);
            var resource = _mapper.Map<PortfolioClient, PortfolioClientResource>(result);

            return resource;
        }

        public async Task<IEnumerable<ClientResource>> GetByPortfoloId(Guid portfolioId)
        {
            var result = await Task.Run(() => _unitOfWork.PortfolioClients.GetByPortfolioId(portfolioId)).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);

            return resources;
        }
    }
}
