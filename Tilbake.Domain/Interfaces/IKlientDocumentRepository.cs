using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKlientDocumentRepository
    {
        Task<IEnumerable<KlientDocument>> GetAllAsync(Guid klientId);
        Task<KlientDocument> GetAsync(Guid id);
        Task<int> AddAsync(Guid klientId, KlientDocument klientDocument, List<IFormFile> DocumentFiles);
        Task<int> UpdateAsync(KlientDocument klientDocument);
        Task<int> DeleteAsync(Guid id);
    }
}
