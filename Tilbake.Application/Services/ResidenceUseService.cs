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
    public class ResidenceUseService : IResidenceUseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResidenceUseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ResidenceUseSaveResource resource)
        {
            var residenceUse = _mapper.Map<ResidenceUseSaveResource, ResidenceUse>(resource);
            residenceUse.Id = Guid.NewGuid();

            await _unitOfWork.ResidenceUses.AddAsync(residenceUse);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ResidenceUses.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(ResidenceUseResource resource)
        {
            var residenceUse = _mapper.Map<ResidenceUseResource, ResidenceUse>(resource);
            await _unitOfWork.ResidenceUses.DeleteAsync(residenceUse);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ResidenceUseResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ResidenceUses.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<ResidenceUse>, IEnumerable<ResidenceUseResource>>(result);

            return resources;
        }

        public async Task<ResidenceUseResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ResidenceUses.GetByIdAsync(id);
            var resource = _mapper.Map<ResidenceUse, ResidenceUseResource>(result);

            return resource;
        }

        public async Task<int> UpdateAsync(ResidenceUseResource resource)
        {
            var residenceUse = _mapper.Map<ResidenceUseResource, ResidenceUse>(resource);
            await _unitOfWork.ResidenceUses.UpdateAsync(resource.Id, residenceUse);

            return await _unitOfWork.SaveAsync();
        }
    }
}
