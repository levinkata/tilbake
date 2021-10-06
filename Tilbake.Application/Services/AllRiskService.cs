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
    public class AllRiskService : IAllRiskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllRiskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(AllRiskSaveResource resource)
        {
            var allRisk = _mapper.Map<AllRiskSaveResource, AllRisk>(resource);
            allRisk.Id = Guid.NewGuid();

            await _unitOfWork.AllRisks.AddAsync(allRisk);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.AllRisks.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(AllRiskResource resource)
        {
            var allRisk = _mapper.Map<AllRiskResource, AllRisk>(resource);
            await _unitOfWork.AllRisks.DeleteAsync(allRisk);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AllRiskResource>> GetAllAsync()
        {
            var result = await _unitOfWork.AllRisks.GetAllAsync();
            result = result.OrderBy(n => n.RiskItem.Description);

            var resources = _mapper.Map<IEnumerable<AllRisk>, IEnumerable<AllRiskResource>>(result);

            return resources;
        }

        public async Task<AllRiskResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.AllRisks.GetByIdAsync(id);
            var resource = _mapper.Map<AllRisk, AllRiskResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(AllRiskResource resource)
        {
            var allRisk = _mapper.Map<AllRiskResource, AllRisk>(resource);
            await _unitOfWork.AllRisks.UpdateAsync(resource.Id, allRisk);

            return await _unitOfWork.SaveAsync();
        }
    }
}
