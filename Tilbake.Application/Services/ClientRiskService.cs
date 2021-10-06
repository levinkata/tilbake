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
    public class ClientRiskService : IClientRiskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientRiskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ClientRiskSaveResource resource)
        {
            var clientRisk = _mapper.Map<ClientRiskSaveResource, ClientRisk>(resource);
            clientRisk.Id = Guid.NewGuid();

            await _unitOfWork.ClientRisks.AddAsync(clientRisk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ClientRisks.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(ClientRiskResource resource)
        {
            var clientRisk = _mapper.Map<ClientRiskResource, ClientRisk>(resource);
            await _unitOfWork.ClientRisks.DeleteAsync(clientRisk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientRiskResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ClientRisks.GetAllAsync();
            var resources = _mapper.Map<IEnumerable<ClientRisk>, IEnumerable<ClientRiskResource>>(result);

            return resources;
        }

        public async Task<ClientRiskResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ClientRisks.GetByIdAsync(id);
            var resources = _mapper.Map<ClientRisk, ClientRiskResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ClientRiskResource resource)
        {
            var clientRisk = _mapper.Map<ClientRiskResource, ClientRisk>(resource);
            await _unitOfWork.ClientRisks.UpdateAsync(resource.Id, clientRisk);

            return await _unitOfWork.SaveAsync();
        }
    }
}
