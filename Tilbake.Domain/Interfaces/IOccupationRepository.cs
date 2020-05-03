using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IOccupationRepository
    {
        Task<IEnumerable<Occupation>> GetAllAsync();
        Task<Occupation> GetAsync(Guid id);
        Task<int> AddAsync(Occupation occupation);
        Task<int> UpdateAsync(Occupation occupation);
        Task<int> DeleteAsync(Guid id);
    }
}
