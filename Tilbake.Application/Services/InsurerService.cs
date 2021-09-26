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
            insurer.DateAdded = DateTime.Now;

            await _unitOfWork.Insurers.AddAsync(insurer);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.Insurers.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(InsurerResource resource)
        {
            var insurer = _mapper.Map<InsurerResource, Insurer>(resource);
            await _unitOfWork.Insurers.DeleteAsync(insurer);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<InsurerResource>> GetAllAsync()
        {
            var result = await _unitOfWork.Insurers.GetAllAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name),
                                            r => r.InsurerBranches);

            var resources = _mapper.Map<IEnumerable<Insurer>, IEnumerable<InsurerResource>>(result);

            return resources;
        }

        public async Task<InsurerResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.Insurers.GetFirstOrDefaultAsync(
                                            r => r.Id == id,
                                            r => r.InsurerBranches);

            var resources = _mapper.Map<Insurer, InsurerResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(InsurerResource resource)
        {
            var insurer = _mapper.Map<InsurerResource, Insurer>(resource);
            insurer.DateModified = DateTime.Now;
            await _unitOfWork.Insurers.UpdateAsync(resource.Id, insurer);

            return await _unitOfWork.SaveAsync();
        }
    }
}
