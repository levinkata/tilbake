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

            await _unitOfWork.RatingMotorDiscounts.AddAsync(ratingMotorDiscount);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.RatingMotorDiscounts.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(RatingMotorDiscountResource resource)
        {
            var ratingMotorDiscount = _mapper.Map<RatingMotorDiscountResource, RatingMotorDiscount>(resource);
            await _unitOfWork.RatingMotorDiscounts.DeleteAsync(ratingMotorDiscount);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorDiscountResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetFirstOrDefaultAsync(
                                                        r => r.Id == id,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotorDiscount, RatingMotorDiscountResource>(result);
            return resource;
        }

        public async Task<IEnumerable<RatingMotorDiscountResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorDiscounts.GetAllAsync(
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

            await _unitOfWork.RatingMotorDiscounts.UpdateAsync(resource.Id, ratingMotorDiscount);
            return await _unitOfWork.SaveAsync();
        }
    }
}
