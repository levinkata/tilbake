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

            _unitOfWork.DocumentTypes.Add(documentType);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            _unitOfWork.DocumentTypes.Delete(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DocumentTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.DocumentTypes.GetAsync(
                                            null,
                                            r => r.OrderBy(n => n.Name));

            var resources = _mapper.Map<IEnumerable<DocumentType>, IEnumerable<DocumentTypeResource>>(result);
            return resources;
        }

        public async Task<DocumentTypeResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.DocumentTypes.GetByIdAsync(id);
            var resource = _mapper.Map<DocumentType, DocumentTypeResource>(result);
            return resource;
        }

        public async Task<int> UpdateAsync(DocumentTypeResource resource)
        {
            var documentType = _mapper.Map<DocumentTypeResource, DocumentType>(resource);
            _unitOfWork.DocumentTypes.Update(resource.Id, documentType);

            return await _unitOfWork.SaveAsync();
        }
    }
}
