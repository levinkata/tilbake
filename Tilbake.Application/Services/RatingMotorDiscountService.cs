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
    public class RatingMotorDiscountService : IRatingMotorDiscountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingMotorDiscountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(RatingMotorDiscountSaveResource resource)
        {
            var ratingMotorDiscount = _mapper.Map<RatingMotorDiscountSaveResource, RatingMotorDiscount>(resource);
            ratingMotorDiscount.Id = Guid.NewGuid();
            ratingMotorDiscount.DateAdded = DateTime.Now;

            _unitOfWork.RatingMotorDiscounts.Add(ratingMotorDiscount);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.RatingMotorDiscounts.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorDiscountResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetAsync(
                                                        r => r.Id == id, null,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotorDiscount, RatingMotorDiscountResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<IEnumerable<RatingMotorDiscountResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetAsync(
                                            r => r.InsurerId == insurerId,
                                            r => r.OrderBy(p => p.ClaimFreeGroup),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<RatingMotorDiscount>, IEnumerable<RatingMotorDiscountResource>>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(RatingMotorDiscountResource resource)
        {
            var ratingMotorDiscount = _mapper.Map<RatingMotorDiscountResource, RatingMotorDiscount>(resource);
            ratingMotorDiscount.DateModified = DateTime.Now;

            _unitOfWork.RatingMotorDiscounts.Update(resource.Id, ratingMotorDiscount);
            return await _unitOfWork.SaveAsync();
        }
    }
}
