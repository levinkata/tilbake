using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Core.Models;
using Tilbake.Core;

namespace Tilbake.Application.Services
{
    public class RiskService : IRiskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(RiskSaveResource resource)
        {
            var risk = _mapper.Map<RiskSaveResource, Risk>(resource);
            risk.Id = Guid.NewGuid();

            _unitOfWork.Risks.Add(risk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Risks.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RiskResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Risks.GetAsync(null);
            var resources = _mapper.Map<IEnumerable<Risk>, IEnumerable<RiskResource>>(result);

            return resources;
        }

        public async Task<RiskResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Risks.GetByIdAsync(id);
            var resources = _mapper.Map<Risk, RiskResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(RiskResource resource)
        {
            var risk = _mapper.Map<RiskResource, Risk>(resource);
            _unitOfWork.Risks.Update(resource.Id, risk);

            return await _unitOfWork.SaveAsync();
        }
    }
}
