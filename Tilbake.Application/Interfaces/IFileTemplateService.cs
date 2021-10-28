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
        void Add(FileTemplateSaveResource resource);
        void Update(FileTemplateResource resource);
        void Delete(Guid id);
    }
}
