using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IGenderRepository
    {
        Task<IQueryable<Gender>> GetAllAsync();
        Task<Gender> GetByIdAsync(Guid id);
        Task<Gender> AddAsync(Gender gender);
        Task <IQueryable<Gender>> AddRangeAsync (IQueryable<Gender> genders);
        Task<Gender> UpdateAsync(Gender gender);
        Task<Gender> DeleteAsync(Guid id);
        Task<Gender> DeleteAsync(Gender gender);
        Task<IQueryable<Gender>> DeleteRangeAsync(IQueryable<Gender> genders);  
    }    
}