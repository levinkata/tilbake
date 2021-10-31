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

        public async void Add(GenderSaveResource resource)
        {
            var gender = _mapper.Map<GenderSaveResource, Gender>(resource);
            gender.Id = Guid.NewGuid();

            _unitOfWork.Genders.Add(gender);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Genders.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<GenderResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Genders.FindAllAsync(
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

        public async void Update(GenderResource resource)
        {
            var gender = _mapper.Map<GenderResource, Gender>(resource);
            _unitOfWork.Genders.Update(resource.Id, gender);
            _unitOfWork.SaveAsync();
        }
    }
}
