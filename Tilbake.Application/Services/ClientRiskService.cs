﻿using AutoMapper;
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

            _unitOfWork.ClientRisks.Add(clientRisk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.ClientRisks.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ClientRiskResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ClientRisks.GetAsync();
            var resources = _mapper.Map<IEnumerable<ClientRisk>, IEnumerable<ClientRiskResource>>(result);

            return resources;
        }

        public async Task<ClientRiskResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ClientRisks.GetByIdAsync(id);
            var resource = _mapper.Map<ClientRisk, ClientRiskResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(ClientRiskResource resource)
        {
            var clientRisk = _mapper.Map<ClientRiskResource, ClientRisk>(resource);
            _unitOfWork.ClientRisks.Update(resource.Id, clientRisk);

            return await _unitOfWork.SaveAsync();
        }
    }
}
