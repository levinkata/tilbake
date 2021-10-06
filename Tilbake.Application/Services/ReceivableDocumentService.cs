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
    public class ReceivableDocumentService : IReceivableDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReceivableDocumentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddAsync(ReceivableDocumentSaveResource resource)
        {
            var receivableDocument = _mapper.Map<ReceivableDocumentSaveResource, ReceivableDocument>(resource);
            receivableDocument.Id = Guid.NewGuid();

            await _unitOfWork.ReceivableDocuments.AddAsync(receivableDocument);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            await _unitOfWork.ReceivableDocuments.DeleteAsync(id);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<int> DeleteAsync(ReceivableDocumentResource resource)
        {
            var receivableDocument = _mapper.Map<ReceivableDocumentResource, ReceivableDocument>(resource);
            await _unitOfWork.ReceivableDocuments.DeleteAsync(receivableDocument);

            return await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ReceivableDocumentResource>> GetAllAsync()
        {
            var result = await _unitOfWork.ReceivableDocuments.GetAllAsync(
                                                            null,
                                                            r => r.OrderBy(p => p.Name),
                                                            r => r.DocumentType);

            var resources = _mapper.Map<IEnumerable<ReceivableDocument>, IEnumerable<ReceivableDocumentResource>>(result);

            return resources;
        }

        public async Task<ReceivableDocumentResource> GetByIdAsync(Guid id)
        {
            var result = await _unitOfWork.ReceivableDocuments.GetFirstOrDefaultAsync(
                                                        r => r.Id == id,
                                                        r => r.DocumentType);

            var resources = _mapper.Map<ReceivableDocument, ReceivableDocumentResource>(result);

            return resources;
        }

        public async Task<IEnumerable<ReceivableDocumentResource>> GetReceivableIdAsync(Guid receivableId)
        {
            var result = await _unitOfWork.ReceivableDocuments.GetAllAsync(
                                                            r => r.ReceivableId == receivableId,
                                                            r => r.OrderBy(p => p.Name),
                                                            r => r.DocumentType);

            var resources = _mapper.Map<IEnumerable<ReceivableDocument>, IEnumerable<ReceivableDocumentResource>>(result);

            return resources;
        }

        public async Task<int> UpdateAsync(ReceivableDocumentResource resource)
        {
            var receivableDocument = _mapper.Map<ReceivableDocumentResource, ReceivableDocument>(resource);
            await _unitOfWork.ReceivableDocuments.UpdateAsync(resource.Id, receivableDocument);

            return await _unitOfWork.SaveAsync();
        }
    }
}
