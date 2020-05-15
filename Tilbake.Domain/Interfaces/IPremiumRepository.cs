using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IPremiumRepository
    {
        Task<IEnumerable<Premium>> GetAllAsync();
        Task<Premium> GetAsync(Guid id);
        Task<int> AddAsync(Premium premium);
        Task<int> UpdateAsync(Premium premium);
        Task<int> DeleteAsync(Guid id);
    }
}
