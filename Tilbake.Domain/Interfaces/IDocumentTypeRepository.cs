using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task<IEnumerable<DocumentType>> GetAllAsync();
        Task<DocumentType> GetAsync(Guid id);
        Task<int> AddAsync(DocumentType documentType);
        Task<int> UpdateAsync(DocumentType documentType);
        Task<int> DeleteAsync(Guid id);
    }
}