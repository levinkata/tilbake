using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface ILandRepository
    {
        Task<IEnumerable<Land>> GetAllAsync();
        Task<Land> GetAsync(Guid id);
        Task<int> AddAsync(Land land);
        Task<int> UpdateAsync(Land land);
        Task<int> DeleteAsync(Guid id);
    }
}
