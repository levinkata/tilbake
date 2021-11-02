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
            gender.DateAdded = DateTime.Now;

            _unitOfWork.Genders.Add(gender);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.Genders.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<GenderResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Genders.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<Gender>, IEnumerable<GenderResource>>(result);
            return resources;
        }

        public async Task<GenderResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Genders.GetByIdAsync(id);
            var resource = _mapper.Map<Gender, GenderResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(GenderResource resource)
        {
            var gender = _mapper.Map<GenderResource, Gender>(resource);
            _unitOfWork.Genders.Update(resource.Id, gender);
            return await _unitOfWork.SaveAsync();
        }
    }
}
