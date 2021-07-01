using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IOccupationRepository
    {
        Task<IQueryable<Occupation>> GetAllAsync();
        Task<Occupation> GetByIdAsync(Guid id);
        Task<Occupation> AddAsync(Occupation occupation);
        Task <IQueryable<Occupation>> AddRangeAsync (IQueryable<Occupation> occupations);
        Task<Occupation> UpdateAsync(Occupation occupation);
        Task<Occupation> DeleteAsync(Guid id);
        Task<Occupation> DeleteAsync(Occupation occupation);
        Task<IQueryable<Occupation>> DeleteRangeAsync(IQueryable<Occupation> occupations);  
    }    
}