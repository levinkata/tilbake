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

            await _unitOfWork.ResidenceUses.AddAsync(residenceUse).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ResidenceUses.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(ResidenceUseResource resource)
        {
            var residenceUse = _mapper.Map<ResidenceUseResource, ResidenceUse>(resource);
            await _unitOfWork.ResidenceUses.DeleteAsync(residenceUse).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<ResidenceUseResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.ResidenceUses.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<ResidenceUse>, IEnumerable<ResidenceUseResource>>(result);

            return resources;
        }

        public async Task<ResidenceUseResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ResidenceUses.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<ResidenceUse, ResidenceUseResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ResidenceUseResource resource)
        {
            var residenceUse = _mapper.Map<ResidenceUseResource, ResidenceUse>(resource);
            await _unitOfWork.ResidenceUses.UpdateAsync(resource.Id, residenceUse).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
