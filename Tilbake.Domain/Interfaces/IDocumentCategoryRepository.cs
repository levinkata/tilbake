using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IDocumentCategoryRepository
    {
        Task<IEnumerable<DocumentCategory>> GetAllAsync();
        Task<DocumentCategory> GetAsync(Guid id);
        Task<int> AddAsync(DocumentCategory documentCategory);
        Task<int> UpdateAsync(DocumentCategory documentCategory);
        Task<int> DeleteAsync(Guid id);
    }
}