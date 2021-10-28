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
        void Add(HouseConditionSaveResource resource);
        void Update(HouseConditionResource resource);
        void Delete(Guid id);
    }
}
