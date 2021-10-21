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
    public class AllRiskSpecifiedService : IAllRiskSpecifiedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllRiskSpecifiedService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AllRiskSpecifiedResource> AddAsync(AllRiskSpecifiedSaveResource resource)
        {
            var allRiskSpecified = _mapper.Map<AllRiskSpecifiedSaveResource, AllRiskSpecified>(resource);
            allRiskSpecified.Id = Guid.NewGuid();
            allRiskSpecified.DateAdded = DateTime.Now;

            await _unitOfWork.AllRiskSpecifieds.AddAsync(allRiskSpecified);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<AllRiskSpecified, AllRiskSpecifiedResource>(allRiskSpecified) ;
            return result;
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.AllRiskSpecifieds.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(AllRiskSpecifiedResource resource)
        {
            var allRiskSpecified = _mapper.Map<AllRiskSpecifiedResource, AllRiskSpecified>(resource);
            await _unitOfWork.AllRiskSpecifieds.DeleteAsync(allRiskSpecified);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AllRiskSpecifiedResource>> GetAllAsync()
        {
            var result = await _unitOfWork.AllRiskSpecifieds.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.RiskItem.Description));

            var resources = _mapper.Map<IEnumerable<AllRiskSpecified>, IEnumerable<AllRiskSpecifiedResource>>(result);
            return resources;
        }

        public async Task<AllRiskSpecifiedResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.AllRiskSpecifieds.GetByIdAsync(id);
            var resource = _mapper.Map<AllRiskSpecified, AllRiskSpecifiedResource>(result);

            return resource;
        }

        public async Task<AllRiskSpecifiedResource> UpdateAsync(AllRiskSpecifiedResource resource)
        {
            var allRiskSpecified = _mapper.Map<AllRiskSpecifiedResource, AllRiskSpecified>(resource);
            allRiskSpecified.DateModified = DateTime.Now;

            await _unitOfWork.AllRiskSpecifieds.UpdateAsync(resource.Id, allRiskSpecified);
            await _unitOfWork.SaveAsync();

            var result = _mapper.Map<AllRiskSpecified, AllRiskSpecifiedResource>(allRiskSpecified) ;
            return result;
        }
    }
}
