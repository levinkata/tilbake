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
    public class RatingMotorService : IRatingMotorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RatingMotorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(RatingMotorSaveResource resource)
        {
            var ratingMotor = _mapper.Map<RatingMotorSaveResource, RatingMotor>(resource);
            ratingMotor.Id = Guid.NewGuid();
            ratingMotor.DateAdded = DateTime.Now;

            _unitOfWork.RatingMotors.Add(ratingMotor);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.RatingMotors.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<RatingMotorResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.RatingMotors.GetFirstOrDefaultAsync(
                                                        r => r.Id == id,
                                                        r => r.Insurer);

            var resource = _mapper.Map<RatingMotor, RatingMotorResource>(result);
            return resource;
        }

        public async Task<IEnumerable<RatingMotorResource>> GetByInsurerAsync(Guid insurerId)
        {
            var result = await _unitOfWork.RatingMotors.GetAllAsync(
                                            r => r.InsurerId == insurerId,
                                            r => r.OrderBy(p => p.StartValue),
                                            r => r.Insurer);

            var resources = _mapper.Map<IEnumerable<RatingMotor>, IEnumerable<RatingMotorResource>>(result);
            return resources;
        }

        public async void Update(RatingMotorResource resource)
        {
            var ratingMotor = _mapper.Map<RatingMotorResource, RatingMotor>(resource);
            ratingMotor.DateModified = DateTime.Now;

            _unitOfWork.RatingMotors.Update(resource.Id, ratingMotor);
            await _unitOfWork.SaveAsync();
        }
    }
}
