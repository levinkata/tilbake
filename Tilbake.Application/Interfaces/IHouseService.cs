using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IHouseService
    {
        Task<IEnumerable<HouseResource>> GetAllAsync();
        Task<HouseResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(HouseSaveResource resource);
        Task<int> UpdateAsync(HouseResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(HouseResource resource);
    }
}
