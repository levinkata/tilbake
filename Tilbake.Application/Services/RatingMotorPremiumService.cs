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
    public class RatingMotorPremiumService : IRatingMotorPremiumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingMotorPremiumService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(RatingMotorPremiumSaveResource resource)
        {
            var ratingMotorPremium = _mapper.Map<RatingMotorPremiumSaveResource, RatingMotorPremium>(resource);
            ratingMotorPremium.Id = Guid.NewGuid();
            ratingMotorPremium.DateAdded = DateTime.Now;

            _unitOfWork.RatingMotorPremiums.Add(ratingMotorPremium);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.RatingMotorPremiums.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorPremiumResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetAsync(
                                                        r => r.Id == id, null,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotorPremium, RatingMotorPremiumResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<IEnumerable<RatingMotorPremiumResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetAsync(
                                            r => r.InsurerId == insurerId,
                                            r => r.OrderBy(p => p.MinimumMonthly),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<RatingMotorPremium>, IEnumerable<RatingMotorPremiumResource>>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(RatingMotorPremiumResource resource)
        {
            var ratingMotorPremium = _mapper.Map<RatingMotorPremiumResource, RatingMotorPremium>(resource);
            ratingMotorPremium.DateModified = DateTime.Now;

            _unitOfWork.RatingMotorPremiums.Update(resource.Id, ratingMotorPremium);
            return await _unitOfWork.SaveAsync();
        }
    }
}
