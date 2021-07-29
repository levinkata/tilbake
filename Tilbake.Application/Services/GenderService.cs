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
    public class GenderService : IGenderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(GenderSaveResource resource)
        {
            var gender = _mapper.Map<GenderSaveResource, Gender>(resource);
            gender.Id = Guid.NewGuid();

            await _unitOfWork.Genders.AddAsync(gender);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Genders.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(GenderResource resource)
        {
            var gender = _mapper.Map<GenderResource, Gender>(resource);
            await _unitOfWork.Genders.DeleteAsync(gender);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<GenderResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Genders.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Gender>, IEnumerable<GenderResource>>(result);

            return resources;
        }

        public async Task<GenderResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Genders.GetByIdAsync(id);
            var resources = _mapper.Map<Gender, GenderResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(GenderResource resource)
        {
            var gender = _mapper.Map<GenderResource, Gender>(resource);
            await _unitOfWork.Genders.UpdateAsync(resource.Id, gender);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
