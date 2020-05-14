using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IDocumentTypeService
    {
        Task<DocumentTypesViewModel> GetAllAsync();
        Task<DocumentTypeViewModel> GetAsync(Guid id);
        Task<int> AddAsync(DocumentTypeViewModel model);
        Task<int> UpdateAsync(DocumentTypeViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}
