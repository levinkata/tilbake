using AutoMapper;
using System;
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

        public async Task<int> AddAsync(PortfolioClientSaveResource resource)
        {
            var portfolioClient = _mapper.Map<PortfolioClientSaveResource, PortfolioClient>(resource);
            portfolioClient.Id = Guid.NewGuid();

            await _unitOfWork.PortfolioClients.AddAsync(portfolioClient);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> AddClientAsync(ClientSaveResource resource)
        {
            var client = _mapper.Map<ClientSaveResource, Client>(resource);
            client.Id = Guid.NewGuid();

            await _unitOfWork.PortfolioClients.AddClientAsync(resource.PortfolioId, client);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.PortfolioClients.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<bool> ExistsAsync(Guid portfolioId, Guid clientId)
        {
            return await _unitOfWork.PortfolioClients.ExistsAsync(portfolioId, clientId);
        }

        public async Task<PortfolioClientResource> FindAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioClients.FindAsync(p => p.Id == id);
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
            return await _unitOfWork.PortfolioClients.GetPortfolioClientId(portfolioId, clientId);
        }
    }
}
