using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IGenderRepository
    {
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<Gender> GetByIdAsync(Guid id);
        Task<Gender> AddAsync(Gender gender);
        Task <IEnumerable<Gender>> AddRangeAsync (IEnumerable<Gender> genders);
        Task<Gender> UpdateAsync(Gender gender);
        Task<Gender> DeleteAsync(Guid id);
        Task<Gender> DeleteAsync(Gender gender);
        Task<IEnumerable<Gender>> DeleteRangeAsync(IEnumerable<Gender> genders);  
    }    
}