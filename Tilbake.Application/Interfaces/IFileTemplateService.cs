using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IFileTemplateService
    {
        Task<IEnumerable<FileTemplateResource>> GetAllAsync();
        Task<IEnumerable<FileTemplateResource>> GetByPortfolioIdAsync(Guid portfolioId);
        Task<FileTemplateResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(FileTemplateSaveResource resource);
        Task<int> UpdateAsync(FileTemplateResource resource);
        Task<int> DeleteAsync(Guid id);
    }
}
