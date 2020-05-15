using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IPremiumTypeRepository
    {
        Task<IEnumerable<PremiumType>> GetAllAsync();
        Task<PremiumType> GetAsync(Guid id);
        Task<int> AddAsync(PremiumType premiumType);
        Task<int> UpdateAsync(PremiumType premiumType);
        Task<int> DeleteAsync(Guid id);
    }
}
