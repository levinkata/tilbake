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

            await _unitOfWork.CommissionRates.AddAsync(commissionRate);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.CommissionRates.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(CommissionRateResource resource)
        {
            var commissionRate = _mapper.Map<CommissionRateResource, CommissionRate>(resource);
            await _unitOfWork.CommissionRates.DeleteAsync(commissionRate);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<CommissionRateResource>> GetAllAsync()
        {
            var result = await _unitOfWork.CommissionRates.GetAllAsync(
                                                null,
                                                r => r.OrderBy(n => n.RiskName));

            var resources = _mapper.Map<IEnumerable<CommissionRate>, IEnumerable<CommissionRateResource>>(result);

            return resources;
        }

        public async Task<CommissionRateResource> GetByRisk(string riskName)
        {
            var result = await _unitOfWork.CommissionRates.GetFirstOrDefaultAsync(
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

        public async Task<int> UpdateAsync(CommissionRateResource resource)
        {
            var commissionRate = _mapper.Map<CommissionRateResource, CommissionRate>(resource);
            await _unitOfWork.CommissionRates.UpdateAsync(resource.Id, commissionRate);

            return await _unitOfWork.SaveAsync();
        }
    }
}
