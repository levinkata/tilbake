using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class DocumentTypeService : IDocumentTypeService
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeService(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        public async Task<int> AddAsync(DocumentTypeViewModel model)
        {
            return await Task.Run(() => _documentTypeRepository.AddAsync(model.DocumentType)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _documentTypeRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<DocumentTypesViewModel> GetAllAsync()
        {
            return new DocumentTypesViewModel()
            {
                DocumentTypes = await Task.Run(() => _documentTypeRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<DocumentTypeViewModel> GetAsync(Guid id)
        {
            return new DocumentTypeViewModel()
            {
                DocumentType = await Task.Run(() => _documentTypeRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(DocumentTypeViewModel model)
        {
            return await Task.Run(() => _documentTypeRepository.UpdateAsync(model.DocumentType)).ConfigureAwait(true);
        }
    }
}
