using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IKravStatusRepository
    {
        Task<IEnumerable<KravStatus>> GetAllAsync();
        Task<KravStatus> GetAsync(Guid id);
        Task<int> AddAsync(KravStatus kravStatus);
        Task<int> UpdateAsync(KravStatus kravStatus);
        Task<int> DeleteAsync(Guid id);
    }
}
