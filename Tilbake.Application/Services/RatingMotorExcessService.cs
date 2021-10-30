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

        public async void Add(RatingMotorExcessSaveResource resource)
        {
            var ratingMotorExcess = _mapper.Map<RatingMotorExcessSaveResource, RatingMotorExcess>(resource);
            ratingMotorExcess.Id = Guid.NewGuid();
            ratingMotorExcess.DateAdded = DateTime.Now;

            _unitOfWork.RatingMotorExcesses.Add(ratingMotorExcess);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.RatingMotorExcesses.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorExcessResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetFirstOrDefaultAsync(
                                                        r => r.Id == id,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotorExcess, RatingMotorExcessResource>(result);
            return resource;
        }

        public async Task<IEnumerable<RatingMotorExcessResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotorExcesses.GetAllAsync(
                                            r => r.InsurerId == insurerId,
                                            r => r.OrderBy(p => p.StartValue),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<RatingMotorExcess>, IEnumerable<RatingMotorExcessResource>>(result);
            return resources;
        }

        public async void Update(RatingMotorExcessResource resource)
        {
            var ratingMotorExcess = _mapper.Map<RatingMotorExcessResource, RatingMotorExcess>(resource);
            ratingMotorExcess.DateModified = DateTime.Now;

            _unitOfWork.RatingMotorExcesses.Update(resource.Id, ratingMotorExcess);
            await _unitOfWork.SaveAsync();
        }
    }
}
