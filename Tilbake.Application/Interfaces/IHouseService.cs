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
        void Add(HouseSaveResource resource);
        void Update(HouseResource resource);
        void Delete(Guid id);
    }
}
