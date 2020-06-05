using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKlientDocumentRepository
    {
        Task<IEnumerable<KlientDocument>> GetAllAsync();
        Task<IEnumerable<KlientDocument>> GetByKlientAsync(Guid klientId);
        Task<KlientDocument> GetAsync(Guid id);
        Task<int> AddAsync( KlientDocument klientDocument);
        Task<int> UpdateAsync(KlientDocument klientDocument);
        Task<int> DeleteAsync(Guid id);
    }
}
