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
    public class InsurerService : IInsurerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsurerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(InsurerSaveResource resource)
        {
            var insurer = _mapper.Map<InsurerSaveResource, Insurer>(resource);
            insurer.Id = Guid.NewGuid();

            await _unitOfWork.Insurers.AddAsync(insurer).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Insurers.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(InsurerResource resource)
        {
            var insurer = _mapper.Map<InsurerResource, Insurer>(resource);
            await _unitOfWork.Insurers.DeleteAsync(insurer).ConfigureAwait(true);
            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }

        public async Task<IEnumerable<InsurerResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.Insurers.GetAllAsync()).ConfigureAwait(true);
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<Insurer>, IEnumerable<InsurerResource>>(result);

            return resources;
        }

        public async Task<InsurerResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Insurers.GetByIdAsync(id).ConfigureAwait(true);
            var resources = _mapper.Map<Insurer, InsurerResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(InsurerResource resource)
        {
            var insurer = _mapper.Map<InsurerResource, Insurer>(resource);
            await _unitOfWork.Insurers.UpdateAsync(resource.Id, insurer).ConfigureAwait(true);

            return await Task.Run(() => _unitOfWork.SaveAsync()).ConfigureAwait(true);
        }
    }
}
