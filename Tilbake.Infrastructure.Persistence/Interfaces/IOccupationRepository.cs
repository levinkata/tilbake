using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IOccupationRepository
    {
        Task<IEnumerable<Occupation>> GetAllAsync();
        Task<Occupation> GetByIdAsync(Guid id);
        Task<Occupation> AddAsync(Occupation occupation);
        Task <IEnumerable<Occupation>> AddRangeAsync (IEnumerable<Occupation> occupations);
        Task<Occupation> UpdateAsync(Occupation occupation);
        Task<Occupation> DeleteAsync(Guid id);
        Task<Occupation> DeleteAsync(Occupation occupation);
        Task<IEnumerable<Occupation>> DeleteRangeAsync(IEnumerable<Occupation> occupations);  
    }    
}