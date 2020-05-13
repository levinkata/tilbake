using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IDriverTypeRepository
    {
        Task<IEnumerable<DriverType>> GetAllAsync();
        Task<DriverType> GetAsync(Guid id);
        Task<int> AddAsync(DriverType driverType);
        Task<int> UpdateAsync(DriverType driverType);
        Task<int> DeleteAsync(Guid id);
    }
}
