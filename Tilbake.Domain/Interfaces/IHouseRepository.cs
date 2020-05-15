using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IHouseRepository
    {
        Task<IEnumerable<House>> GetAllAsync();
        Task<House> GetAsync(Guid id);
        Task<int> AddAsync(Guid klientId, House house);
        Task<int> UpdateAsync(House house);
        Task<int> DeleteAsync(Guid id);
    }
}
