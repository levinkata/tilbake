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
    public class InsurerService : IInsurerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsurerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(InsurerSaveResource resource)
        {
            var insurer = _mapper.Map<InsurerSaveResource, Insurer>(resource);
            insurer.Id = Guid.NewGuid();
            insurer.DateAdded = DateTime.Now;

            _unitOfWork.Insurers.Add(insurer);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.Insurers.Delete(id);
            await _unitOfWork.SaveAsync();
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

        public async void Update(InsurerResource resource)
        {
            var insurer = _mapper.Map<InsurerResource, Insurer>(resource);
            insurer.DateModified = DateTime.Now;
            _unitOfWork.Insurers.Update(resource.Id, insurer);

            await _unitOfWork.SaveAsync();
        }
    }
}
