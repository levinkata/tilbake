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
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DocumentTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(DocumentTypeSaveResource resource)
        {
            var documentType = _mapper.Map<DocumentTypeSaveResource, DocumentType>(resource);
            documentType.Id = Guid.NewGuid();

            await _unitOfWork.DocumentTypes.AddAsync(documentType);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.DocumentTypes.DeleteAsync(id);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<int> DeleteAsync(DocumentTypeResource resource)
        {
            var documentType = _mapper.Map<DocumentTypeResource, DocumentType>(resource);
            await _unitOfWork.DocumentTypes.DeleteAsync(documentType);
            return await Task.Run(() => _unitOfWork.SaveAsync());
        }

        public async Task<IEnumerable<DocumentTypeResource>> GetAllAsync()
        {
            var result = await Task.Run(() => _unitOfWork.DocumentTypes.GetAllAsync());
            result = result.OrderBy(n => n.Name);

            var resources = _mapper.Map<IEnumerable<DocumentType>, IEnumerable<DocumentTypeResource>>(result);

            return resources;
        }

        public async Task<DocumentTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.DocumentTypes.GetByIdAsync(id);
            var resources = _mapper.Map<DocumentType, DocumentTypeResource>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(DocumentTypeResource resource)
        {
            var documentType = _mapper.Map<DocumentTypeResource, DocumentType>(resource);
            await _unitOfWork.DocumentTypes.UpdateAsync(resource.Id, documentType);

            return await Task.Run(() => _unitOfWork.SaveAsync());
        }
    }
}
