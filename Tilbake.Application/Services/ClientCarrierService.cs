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
    public class ClientCarrierService : IClientCarrierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientCarrierService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClientCarrierResource>> GetByClientIdAsync(Guid clientId)
        {
            var result = await _unitOfWork.ClientCarriers.GetAllAsync(
                r => r.ClientId == clientId,
                r => r.OrderBy(p => p.Carrier.Name),
                r => r.Carrier);

            var resources = _mapper.Map<IEnumerable<ClientCarrier>, IEnumerable<ClientCarrierResource>>(result);

            return resources;
        }
    }
}
