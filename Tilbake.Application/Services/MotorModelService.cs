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
    public class MotorModelService : IMotorModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MotorModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(MotorModelSaveResource resource)
        {
            var motorModel = _mapper.Map<MotorModelSaveResource, MotorModel>(resource);
            motorModel.Id = Guid.NewGuid();

            await _unitOfWork.MotorModels.AddAsync(motorModel);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.MotorModels.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(MotorModelResource resource)
        {
            var motorModel = _mapper.Map<MotorModelResource, MotorModel>(resource);
            await _unitOfWork.MotorModels.DeleteAsync(motorModel);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<MotorModelResource>> GetAllAsync()
        {
            var result = await _unitOfWork.MotorModels.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<MotorModel>, IEnumerable<MotorModelResource>>(result);

            return resources;
        }

        public async Task<MotorModelResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.MotorModels.GetByIdAsync(id);
            var resources = _mapper.Map<MotorModel, MotorModelResource>(result);

            return resources;
        }

        public async Task<IEnumerable<MotorModelResource>> GetByMotorMakeIdAsync(Guid motorMakeId)
        {
            var result = await  _unitOfWork.MotorModels.GetAllAsync(
                                            r => r.MotorMakeId == motorMakeId,
                                            r => r.OrderBy(p => p.Name),
                                            r => r.MotorMake);

            var resources = _mapper.Map<IEnumerable<MotorModel>, IEnumerable<MotorModelResource>>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(MotorModelResource resource)
        {
            var motorModel = _mapper.Map<MotorModelResource, MotorModel>(resource);
            await _unitOfWork.MotorModels.UpdateAsync(resource.Id, motorModel);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
