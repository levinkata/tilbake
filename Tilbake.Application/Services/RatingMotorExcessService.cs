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
    public class RatingMotorExcessService : IRatingMotorExcessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingMotorExcessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(RatingMotorExcessSaveResource resource)
        {
            var ratingMotorExcess = _mapper.Map<RatingMotorExcessSaveResource, RatingMotorExcess>(resource);
            ratingMotorExcess.Id = Guid.NewGuid();
            ratingMotorExcess.DateAdded = DateTime.Now;

            _unitOfWork.RatingMotorExcesses.Add(ratingMotorExcess);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.RatingMotorExcesses.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorExcessResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetAsync(
                                                        r => r.Id == id, null,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotorExcess, RatingMotorExcessResource>(result.FirstOrDefault());
            return resource;
        }

        public async Task<IEnumerable<RatingMotorExcessResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetAsync(
                                            r => r.InsurerId == insurerId,
                                            r => r.OrderBy(p => p.StartValue),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<RatingMotorExcess>, IEnumerable<RatingMotorExcessResource>>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(RatingMotorExcessResource resource)
        {
            var ratingMotorExcess = _mapper.Map<RatingMotorExcessResource, RatingMotorExcess>(resource);
            ratingMotorExcess.DateModified = DateTime.Now;

            _unitOfWork.RatingMotorExcesses.Update(resource.Id, ratingMotorExcess);
            return await _unitOfWork.SaveAsync();
        }
    }
}
