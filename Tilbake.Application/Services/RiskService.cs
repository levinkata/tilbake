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
    public class RiskService : IRiskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RiskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(RiskSaveResource resource)
        {
            var risk = _mapper.Map<RiskSaveResource, Risk>(resource);
            risk.Id = Guid.NewGuid();

            _unitOfWork.Risks.Add(risk);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Risks.Delete(id);
            await _unitOfWork.SaveAsync();
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

        public async void Update(RiskResource resource)
        {
            var risk = _mapper.Map<RiskResource, Risk>(resource);
            _unitOfWork.Risks.Update(resource.Id, risk);

            await _unitOfWork.SaveAsync();
        }
    }
}
