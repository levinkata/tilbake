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
    public class CommissionRateService : ICommissionRateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommissionRateService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(CommissionRateSaveResource resource)
        {
            var commissionRate = _mapper.Map<CommissionRateSaveResource, CommissionRate>(resource);
            commissionRate.Id = Guid.NewGuid();
            commissionRate.DateAdded = DateTime.Now;

            _unitOfWork.CommissionRates.Add(commissionRate);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.CommissionRates.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CommissionRateResource>> GetAllAsync()
        {
            var result = await _unitOfWork.CommissionRates.FindAllAsync(
                                                null,
                                                r => r.OrderBy(n => n.RiskName));

            var resources = _mapper.Map<IEnumerable<CommissionRate>, IEnumerable<CommissionRateResource>>(result);
            return resources;
        }

        public async Task<CommissionRateResource> GetByRisk(string riskName)
        {
            var result = await _unitOfWork.CommissionRates.GetByIdAsync(
                                            e => e.RiskName == riskName);

            var resource = _mapper.Map<CommissionRate, CommissionRateResource>(result);
            return resource;
        }

        public async Task<CommissionRateResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.CommissionRates.GetByIdAsync(id);
            var resource = _mapper.Map<CommissionRate, CommissionRateResource>(result);

            return resource;
        }

        public async void Update(CommissionRateResource resource)
        {
            var commissionRate = _mapper.Map<CommissionRateResource, CommissionRate>(resource);
            commissionRate.DateModified = DateTime.Now;

            _unitOfWork.CommissionRates.Update(resource.Id, commissionRate);
            await _unitOfWork.SaveAsync();
        }
    }
}
