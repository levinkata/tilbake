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
    public class OccupationService : IOccupationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OccupationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(OccupationSaveResource resource)
        {
            var occupation = _mapper.Map<OccupationSaveResource, Occupation>(resource);
            occupation.Id = Guid.NewGuid();

            await _unitOfWork.Occupations.AddAsync(occupation);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Occupations.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(OccupationResource resource)
        {
            var occupation = _mapper.Map<OccupationResource, Occupation>(resource);
            await _unitOfWork.Occupations.DeleteAsync(occupation);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<OccupationResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Occupations.GetAllAsync(
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

        public async Task<int> UpdateAsync(OccupationResource resource)
        {
            var occupation = _mapper.Map<OccupationResource, Occupation>(resource);
            await _unitOfWork.Occupations.UpdateAsync(resource.Id, occupation);

            return await _unitOfWork.SaveAsync();
        }
    }
}
