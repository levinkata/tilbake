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

            _unitOfWork.MotorModels.Add(motorModel);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.MotorModels.Delete(id);
            return await _unitOfWork.SaveAsync();
        }
        public async Task<IEnumerable<MotorModelResource>> GetAllAsync()
        {
            var result = await _unitOfWork.MotorModels.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<MotorModel>, IEnumerable<MotorModelResource>>(result);
            return resources;
        }

        public async Task<MotorModelResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.MotorModels.GetByIdAsync(id);
            var resource = _mapper.Map<MotorModel, MotorModelResource>(result);
            return resource;
        }

        public async Task<IEnumerable<MotorModelResource>> GetByMotorMakeIdAsync(Guid motorMakeId)
        {
            var result = await  _unitOfWork.MotorModels.GetAsync(
                                            r => r.MotorMakeId == motorMakeId,
                                            r => r.OrderBy(p => p.Name),
                                            r => r.MotorMake);

            var resources = _mapper.Map<IEnumerable<MotorModel>, IEnumerable<MotorModelResource>>(result);
            return resources;
        }

        public async Task<int> UpdateAsync(MotorModelResource resource)
        {
            var motorModel = _mapper.Map<MotorModelResource, MotorModel>(resource);
            _unitOfWork.MotorModels.Update(resource.Id, motorModel);

            return await _unitOfWork.SaveAsync();
        }
    }
}
