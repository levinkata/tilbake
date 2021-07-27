using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Resources;

namespace Tilbake.Application.Interfaces
{
    public interface IHouseConditionService
    {
        Task<IEnumerable<HouseConditionResource>> GetAllAsync();
        Task<HouseConditionResource> GetByIdAsync(Guid id);
        Task<int> AddAsync(HouseConditionSaveResource resource);
        Task<int> UpdateAsync(HouseConditionResource resource);
        Task<int> DeleteAsync(Guid id);
        Task<int> DeleteAsync(HouseConditionResource resource);
    }
}
