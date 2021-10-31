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
    public class OccupationService : IOccupationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OccupationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(OccupationSaveResource resource)
        {
            var occupation = _mapper.Map<OccupationSaveResource, Occupation>(resource);
            occupation.Id = Guid.NewGuid();

            _unitOfWork.Occupations.Add(occupation);
            _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Occupations.Delete(id);
            _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OccupationResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Occupations.FindAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<Occupation>, IEnumerable<OccupationResource>>(result);
            return resources;
        }

        public async Task<OccupationResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Occupations.GetByIdAsync(id);
            var resource = _mapper.Map<Occupation, OccupationResource>(result);
            return resource;
        }

        public async void Update(OccupationResource resource)
        {
            var occupation = _mapper.Map<OccupationResource, Occupation>(resource);
            _unitOfWork.Occupations.Update(resource.Id, occupation);

            _unitOfWork.SaveAsync();
        }
    }
}
