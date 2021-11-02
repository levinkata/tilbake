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
    public class ClientCarrierService : IClientCarrierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientCarrierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ClientCarrierSaveResource resource)
        {
            var carrierIds = resource.CarrierIds;
            var clientId = resource.ClientId;

            var existingCarriers = await _unitOfWork.ClientCarriers.GetAsync(
                                                r => r.ClientId == clientId);

            if(existingCarriers.Any())
            {
                _unitOfWork.ClientCarriers.DeleteRange(existingCarriers);
            }

            if(carrierIds.Any())
            {
                List<ClientCarrier> clientCarriers = new();

                foreach (var carrierId in carrierIds)
                {
                    ClientCarrier clientCarrier = new()
                    {
                        ClientId = clientId,
                        CarrierId = carrierId,
                        DateAdded = DateTime.Now
                    };
                    clientCarriers.Add(clientCarrier);
                }
                _unitOfWork.ClientCarriers.AddRange(clientCarriers);
            }
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> UpdateAsync(ClientCarrierResource resource)
        {
            var carrierIds = resource.CarrierIds;
            var clientId = resource.ClientId;

            var existingCarriers = await _unitOfWork.ClientCarriers.GetAsync(
                                                r => r.ClientId == clientId);

            if(existingCarriers.Any())
            {
                _unitOfWork.ClientCarriers.DeleteRange(existingCarriers);
            }

            if(carrierIds.Any())
            {
                List<ClientCarrier> clientCarriers = new();

                foreach (var carrierId in carrierIds)
                {
                    ClientCarrier clientCarrier = new()
                    {
                        ClientId = clientId,
                        CarrierId = carrierId,
                        DateAdded = DateTime.Now
                    };
                    clientCarriers.Add(clientCarrier);
                }
                _unitOfWork.ClientCarriers.AddRange(clientCarriers);
            }
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientCarrierResource>> GetByClientIdAsync(Guid clientId)
        {
            var result = await _unitOfWork.ClientCarriers.GetAsync(
                                                            r => r.ClientId == clientId,
                                                            r => r.OrderBy(p => p.Carrier.Name),
                                                            r => r.Carrier);

            var resources = _mapper.Map<IEnumerable<ClientCarrier>, IEnumerable<ClientCarrierResource>>(result);
            return resources;
        }
    }
}
