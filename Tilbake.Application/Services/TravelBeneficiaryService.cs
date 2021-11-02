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
    public class TravelBeneficiaryService : ITravelBeneficiaryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TravelBeneficiaryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(TravelBeneficiarySaveResource resource)
        {
            var travelBeneficiary = _mapper.Map<TravelBeneficiarySaveResource, TravelBeneficiary>(resource);
            travelBeneficiary.Id = Guid.NewGuid();
            travelBeneficiary.DateAdded = DateTime.Now;

            _unitOfWork.TravelBeneficiaries.Add(travelBeneficiary);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.TravelBeneficiaries.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TravelBeneficiaryResource>> GetAllAsync()
        {
            var result = await _unitOfWork.TravelBeneficiaries.GetAsync(
                                                                null,
                                                                r => r.OrderBy(p => p.LastName),
                                                                r => r.Country,
                                                                r => r.Title);

            var resources = _mapper.Map<IEnumerable<TravelBeneficiary>, IEnumerable<TravelBeneficiaryResource>>(result);
            return resources;
        }

        public async Task<TravelBeneficiaryResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.TravelBeneficiaries.GetAsync(
                                                                r => r.Id == id, null,
                                                                r => r.Country,
                                                                r => r.Title);

            var resource = _mapper.Map<TravelBeneficiary, TravelBeneficiaryResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<int> UpdateAsync(TravelBeneficiaryResource resource)
        {
            var travelBeneficiary = _mapper.Map<TravelBeneficiaryResource, TravelBeneficiary>(resource);
            travelBeneficiary.DateModified = DateTime.Now;

            _unitOfWork.TravelBeneficiaries.Update(resource.Id, travelBeneficiary);
            return await _unitOfWork.SaveAsync();
        }
    }
}
