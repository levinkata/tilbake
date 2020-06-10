using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class DocumentCategoryService : IDocumentCategoryService
    {
        private readonly IDocumentCategoryRepository _documentCategoryRepository;

        public DocumentCategoryService(IDocumentCategoryRepository documentCategoryRepository)
        {
            _documentCategoryRepository = documentCategoryRepository;
        }

        public async Task<int> AddAsync(DocumentCategoryViewModel model)
        {
            return await Task.Run(() => _documentCategoryRepository.AddAsync(model.DocumentCategory)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _documentCategoryRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<DocumentCategoriesViewModel> GetAllAsync()
        {
            return new DocumentCategoriesViewModel()
            {
                DocumentCategories = await Task.Run(() => _documentCategoryRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<DocumentCategoryViewModel> GetAsync(Guid id)
        {
            return new DocumentCategoryViewModel()
            {
                DocumentCategory = await Task.Run(() => _documentCategoryRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(DocumentCategoryViewModel model)
        {
            return await Task.Run(() => _documentCategoryRepository.UpdateAsync(model.DocumentCategory)).ConfigureAwait(true);
        }
    }
}
