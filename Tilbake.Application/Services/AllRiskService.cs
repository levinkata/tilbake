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
    public class AllRiskService : IAllRiskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllRiskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(AllRiskSaveResource resource)
        {
            var allRisk = _mapper.Map<AllRiskSaveResource, AllRisk>(resource);
            allRisk.Id = Guid.NewGuid();
            allRisk.DateAdded = DateTime.Now;

            _unitOfWork.AllRisks.Add(allRisk);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.AllRisks.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AllRiskResource>> GetAllAsync()
        {
            var result = await _unitOfWork.AllRisks.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.RiskItem.Description));

            var resources = _mapper.Map<IEnumerable<AllRisk>, IEnumerable<AllRiskResource>>(result);
            return resources;
        }

        public async Task<AllRiskResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.AllRisks.GetByIdAsync(id);
            var resource = _mapper.Map<AllRisk, AllRiskResource>(result);

            return resource;
        }

        public async void Update(AllRiskResource resource)
        {
            var allRisk = _mapper.Map<AllRiskResource, AllRisk>(resource);
            allRisk.DateModified = DateTime.Now;

            _unitOfWork.AllRisks.Update(resource.Id, allRisk);
            _unitOfWork.SaveAsync();
        }
    }
}
