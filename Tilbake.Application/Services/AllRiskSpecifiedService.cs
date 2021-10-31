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
    public class AllRiskSpecifiedService : IAllRiskSpecifiedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AllRiskSpecifiedService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(AllRiskSpecifiedSaveResource resource)
        {
            var allRiskSpecified = _mapper.Map<AllRiskSpecifiedSaveResource, AllRiskSpecified>(resource);
            allRiskSpecified.Id = Guid.NewGuid();
            allRiskSpecified.DateAdded = DateTime.Now;

            _unitOfWork.AllRiskSpecifieds.Add(allRiskSpecified);
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.AllRiskSpecifieds.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AllRiskSpecifiedResource>> GetAllAsync()
        {
            var result = await _unitOfWork.AllRiskSpecifieds.FindAllAsync(
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

        public async void Update(AllRiskSpecifiedResource resource)
        {
            var allRiskSpecified = _mapper.Map<AllRiskSpecifiedResource, AllRiskSpecified>(resource);
            allRiskSpecified.DateModified = DateTime.Now;

            _unitOfWork.AllRiskSpecifieds.Update(resource.Id, allRiskSpecified);
            _unitOfWork.SaveAsync();
        }
    }
}
