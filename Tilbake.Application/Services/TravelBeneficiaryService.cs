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

            await _unitOfWork.TravelBeneficiaries.AddAsync(travelBeneficiary);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.TravelBeneficiaries.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(TravelBeneficiaryResource resource)
        {
            var travelBeneficiary = _mapper.Map<TravelBeneficiaryResource, TravelBeneficiary>(resource);
            await _unitOfWork.TravelBeneficiaries.DeleteAsync(travelBeneficiary);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TravelBeneficiaryResource>> GetAllAsync()
        {
            var result = await _unitOfWork.TravelBeneficiaries.GetAllAsync(
                                                                null,
                                                                r => r.OrderBy(p => p.LastName),
                                                                r => r.Country,
                                                                r => r.Title);

            var resources = _mapper.Map<IEnumerable<TravelBeneficiary>, IEnumerable<TravelBeneficiaryResource>>(result);
            return resources;
        }

        public async Task<TravelBeneficiaryResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.TravelBeneficiaries.GetFirstOrDefaultAsync(
                                                                r => r.Id == id,
                                                                r => r.Country,
                                                                r => r.Title);

            var resource = _mapper.Map<TravelBeneficiary, TravelBeneficiaryResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(TravelBeneficiaryResource resource)
        {
            var travelBeneficiary = _mapper.Map<TravelBeneficiaryResource, TravelBeneficiary>(resource);
            travelBeneficiary.DateModified = DateTime.Now;

            await _unitOfWork.TravelBeneficiaries.UpdateAsync(resource.Id, travelBeneficiary);
            return await _unitOfWork.SaveAsync();
        }
    }
}
