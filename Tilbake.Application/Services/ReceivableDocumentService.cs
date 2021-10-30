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
    public class ReceivableDocumentService : IReceivableDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceivableDocumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async void Add(ReceivableDocumentSaveResource resource)
        {
            var receivableDocument = _mapper.Map<ReceivableDocumentSaveResource, ReceivableDocument>(resource);
            receivableDocument.Id = Guid.NewGuid();

            _unitOfWork.ReceivableDocuments.Add(receivableDocument);
            await _unitOfWork.SaveAsync();
        }

        public async void Delete(Guid id)
        {
            _unitOfWork.ReceivableDocuments.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ReceivableDocumentResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ReceivableDocuments.FindAllAsync(
                                                            null,
                                                            r => r.OrderBy(p => p.Name),
                                                            r => r.DocumentType);

            var resources = _mapper.Map<IEnumerable<ReceivableDocument>, IEnumerable<ReceivableDocumentResource>>(result);

            return resources;
        }

        public async Task<ReceivableDocumentResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ReceivableDocuments.GetByIdAsync(
                                                        r => r.Id == id,
                                                        r => r.DocumentType);

            var resources = _mapper.Map<ReceivableDocument, ReceivableDocumentResource>(result);

            return resources;
        }

        public async Task<IEnumerable<ReceivableDocumentResource>> GetReceivableIdAsync(Guid receivableId)
        {
            var result = await _unitOfWork.ReceivableDocuments.FindAllAsync(
                                                            r => r.ReceivableId == receivableId,
                                                            r => r.OrderBy(p => p.Name),
                                                            r => r.DocumentType);

            var resources = _mapper.Map<IEnumerable<ReceivableDocument>, IEnumerable<ReceivableDocumentResource>>(result);
            return resources;
        }

        public async void Update(ReceivableDocumentResource resource)
        {
            var receivableDocument = _mapper.Map<ReceivableDocumentResource, ReceivableDocument>(resource);
            _unitOfWork.ReceivableDocuments.Update(resource.Id, receivableDocument);

            await _unitOfWork.SaveAsync();
        }
    }
}
