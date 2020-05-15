using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IGlassRepository
    {
        Task<IEnumerable<Glass>> GetAllAsync();
        Task<Glass> GetAsync(Guid id);
        Task<int> AddAsync(Guid klientId, Glass glass);
        Task<int> UpdateAsync(Glass glass);
        Task<int> DeleteAsync(Guid id);
    }
}
