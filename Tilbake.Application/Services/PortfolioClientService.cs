using AutoMapper;
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

            client.Id = Guid.NewGuid();
            client.DateAdded = DateTime.Now;
            await _unitOfWork.Clients.AddAsync(client);
            var clientId = client.Id;

            PortfolioClient newPortfolioClient = new()
            {
                Id = Guid.NewGuid(),
                PortfolioId = resource.PortfolioId,
                ClientId = clientId,
                DateAdded = DateTime.Now
            };
            await _unitOfWork.PortfolioClients.AddAsync(newPortfolioClient);

            var physicalAddress = resource.PhysicalAddress;
            if (physicalAddress != null)
            {
                Address newAddress = new()
                {
                    Id = Guid.NewGuid(),
                    ClientId = clientId,
                    PhysicalAddress = physicalAddress,
                    PostalAddress = resource.PostalAddress,
                    CityId = resource.CityId,
                    DateAdded = DateTime.Now
                };
                await _unitOfWork.Addresses.AddAsync(newAddress);
            }

            var carrierIds = resource.CarrierIds;
            if (carrierIds != null)
            {
                foreach (var carrierId in carrierIds)
                {
                    ClientCarrier newClientCarrier = new()
                    {
                        ClientId = clientId,
                        CarrierId = carrierId,
                        DateAdded = DateTime.Now
                    };
                    await _unitOfWork.ClientCarriers.AddAsync(newClientCarrier);
                }

            }
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

        public async Task<PortfolioClientResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.PortfolioClients.GetFirstOrDefaultAsync(
                                                            e => e.Id == id,
                                                            e => e.Client);

            var resource = _mapper.Map<PortfolioClient, PortfolioClientResource>(result);
            return resource;
        }

        public async Task<IEnumerable<PortfolioClientResource>> GetByPortfolioIdAsync(Guid portfolioId)
        {
            var result = await _unitOfWork.PortfolioClients.GetAllAsync(
                                                            e => e.PortfolioId == portfolioId,
                                                            e => e.OrderBy(n => n.Client.LastName),
                                                            e => e.Client);

            var resources = _mapper.Map<IEnumerable<PortfolioClient>, IEnumerable< PortfolioClientResource>>(result);
            return resources;
        }

        public async Task<Guid> GetPortfolioClientId(Guid portfolioId, Guid clientId)
        {
            var result = await _unitOfWork.PortfolioClients.GetFirstOrDefaultAsync(
                                            e => e.PortfolioId == portfolioId && e.ClientId == clientId);

            return result.Id;
        }
    }
}
