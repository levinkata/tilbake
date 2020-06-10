using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IDocumentCategoryService
    {
        Task<DocumentCategoriesViewModel> GetAllAsync();
        Task<DocumentCategoryViewModel> GetAsync(Guid id);
        Task<int> AddAsync(DocumentCategoryViewModel model);
        Task<int> UpdateAsync(DocumentCategoryViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
