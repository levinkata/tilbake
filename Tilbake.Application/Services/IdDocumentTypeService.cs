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
    public class IdDocumentTypeService : IIdDocumentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IdDocumentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(IdDocumentTypeSaveResource resource)
        {
            var idDocumentType = _mapper.Map<IdDocumentTypeSaveResource, IdDocumentType>(resource);
            idDocumentType.Id = Guid.NewGuid();
            idDocumentType.DateAdded = DateTime.Now;

            await _unitOfWork.IdDocumentTypes.AddAsync(idDocumentType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.IdDocumentTypes.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(IdDocumentTypeResource resource)
        {
            var idDocumentType = _mapper.Map<IdDocumentTypeResource, IdDocumentType>(resource);
            await _unitOfWork.IdDocumentTypes.DeleteAsync(idDocumentType);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<IdDocumentTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.IdDocumentTypes.GetAllAsync(
                                            null,
                                            r => r.OrderBy(p => p.Name));

            var resources = _mapper.Map<IEnumerable<IdDocumentType>, IEnumerable<IdDocumentTypeResource>>(result);
            return resources;
        }

        public async Task<IdDocumentTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.IdDocumentTypes.GetByIdAsync(id);
            var resource = _mapper.Map<IdDocumentType, IdDocumentTypeResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(IdDocumentTypeResource resource)
        {
            var idDocumentType = _mapper.Map<IdDocumentTypeResource, IdDocumentType>(resource);
            idDocumentType.DateModified = DateTime.Now;

            await _unitOfWork.IdDocumentTypes.UpdateAsync(resource.Id, idDocumentType);
            return await _unitOfWork.SaveAsync();
        }
    }
}
