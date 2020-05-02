using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IInsurerRepository
    {
        Task<IEnumerable<Insurer>> GetAllAsync();
        Task<Insurer> GetAsync(Guid id);
        Task<int> AddAsync(Insurer insurer);
        Task<int> UpdateAsync(Insurer insurer);
        Task<int> DeleteAsync(Guid id);
    }
}
