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
    public class RatingMotorPremiumService : IRatingMotorPremiumService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingMotorPremiumService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(RatingMotorPremiumSaveResource resource)
        {
            var ratingMotorPremium = _mapper.Map<RatingMotorPremiumSaveResource, RatingMotorPremium>(resource);
            ratingMotorPremium.Id = Guid.NewGuid();
            ratingMotorPremium.DateAdded = DateTime.Now;

            _unitOfWork.RatingMotorPremiums.Add(ratingMotorPremium);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.RatingMotorPremiums.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorPremiumResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetFirstOrDefaultAsync(
                                                        r => r.Id == id,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotorPremium, RatingMotorPremiumResource>(result);
            return resource;
        }

        public async Task<IEnumerable<RatingMotorPremiumResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorPremiums.GetAllAsync(
                                            r => r.InsurerId == insurerId,
                                            r => r.OrderBy(p => p.MinimumMonthly),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<RatingMotorPremium>, IEnumerable<RatingMotorPremiumResource>>(result);
            return resources;
        }

        public async void Update(RatingMotorPremiumResource resource)
        {
            var ratingMotorPremium = _mapper.Map<RatingMotorPremiumResource, RatingMotorPremium>(resource);
            ratingMotorPremium.DateModified = DateTime.Now;

            _unitOfWork.RatingMotorPremiums.Update(resource.Id, ratingMotorPremium);
            await _unitOfWork.SaveAsync();
        }
    }
}
