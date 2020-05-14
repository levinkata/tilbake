using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
        Task<Region> GetAsync(Guid id);
        Task<int> AddAsync(Region region);
        Task<int> UpdateAsync(Region region);
        Task<int> DeleteAsync(Guid id);
    }
}