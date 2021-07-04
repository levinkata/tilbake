using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(Guid id);
        Task<Country> AddAsync(Country country);
        Task <IEnumerable<Country>> AddRangeAsync (IEnumerable<Country> countrys);
        Task<Country> UpdateAsync(Country country);
        Task<Country> DeleteAsync(Guid id);
        Task<Country> DeleteAsync(Country country);
        Task<IEnumerable<Country>> DeleteRangeAsync(IEnumerable<Country> countrys);  
    }    
}