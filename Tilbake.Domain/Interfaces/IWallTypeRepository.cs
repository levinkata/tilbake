using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IWallTypeRepository
    {
        Task<IEnumerable<WallType>> GetAllAsync();
        Task<WallType> GetAsync(Guid id);
        Task<int> AddAsync(WallType wallType);
        Task<int> UpdateAsync(WallType wallType);
        Task<int> DeleteAsync(Guid id);
    }
}