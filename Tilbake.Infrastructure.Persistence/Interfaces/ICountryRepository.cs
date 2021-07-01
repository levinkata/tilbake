using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface ICountryRepository
    {
        Task<IQueryable<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(Guid id);
        Task<Country> AddAsync(Country country);
        Task <IQueryable<Country>> AddRangeAsync (IQueryable<Country> countrys);
        Task<Country> UpdateAsync(Country country);
        Task<Country> DeleteAsync(Guid id);
        Task<Country> DeleteAsync(Country country);
        Task<IQueryable<Country>> DeleteRangeAsync(IQueryable<Country> countrys);  
    }    
}