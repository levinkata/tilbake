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

            await _unitOfWork.Risks.AddAsync(risk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Risks.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(RiskResource resource)
        {
            var risk = _mapper.Map<RiskResource, Risk>(resource);
            await _unitOfWork.Risks.DeleteAsync(risk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<RiskResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Risks.GetAllAsync();
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
            await _unitOfWork.Risks.UpdateAsync(resource.Id, risk);

            return await _unitOfWork.SaveAsync();
        }
    }
}
