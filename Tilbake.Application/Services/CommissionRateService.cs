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

        public async Task<int> AddAsync(CommissionRateSaveResource resource)
        {
            var commissionRate = _mapper.Map<CommissionRateSaveResource, CommissionRate>(resource);
            commissionRate.Id = Guid.NewGuid();
            commissionRate.DateAdded = DateTime.Now;

            _unitOfWork.CommissionRates.Add(commissionRate);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.CommissionRates.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CommissionRateResource>> GetAllAsync()
        {
            var result = await _unitOfWork.CommissionRates.GetAsync(
                                                null,
                                                r => r.OrderBy(n => n.RiskName));

            var resources = _mapper.Map<IEnumerable<CommissionRate>, IEnumerable<CommissionRateResource>>(result);
            return resources;
        }

        public async Task<CommissionRateResource> GetByRisk(string riskName)
        {
            var result = await _unitOfWork.CommissionRates.GetAsync(
                                            e => e.RiskName == riskName);

            var resource = _mapper.Map<CommissionRate, CommissionRateResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<CommissionRateResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.CommissionRates.GetByIdAsync(id);
            var resource = _mapper.Map<CommissionRate, CommissionRateResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(CommissionRateResource resource)
        {
            var commissionRate = _mapper.Map<CommissionRateResource, CommissionRate>(resource);
            commissionRate.DateModified = DateTime.Now;

            _unitOfWork.CommissionRates.Update(resource.Id, commissionRate);
            return await _unitOfWork.SaveAsync();
        }
    }
}
