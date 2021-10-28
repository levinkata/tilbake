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

        public async void Add(DocumentTypeSaveResource resource)
        {
            var documentType = _mapper.Map<DocumentTypeSaveResource, DocumentType>(resource);
            documentType.Id = Guid.NewGuid();

            _unitOfWork.DocumentTypes.Add(documentType);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.DocumentTypes.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DocumentTypeResource>> GetAllAsync()
        {
            var result = await _unitOfWork.DocumentTypes.GetAllAsync(
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

        public async void Update(DocumentTypeResource resource)
        {
            var documentType = _mapper.Map<DocumentTypeResource, DocumentType>(resource);
            _unitOfWork.DocumentTypes.Update(resource.Id, documentType);

            await _unitOfWork.SaveAsync();
        }
    }
}
