using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IRoofTypeRepository
    {
        Task<IEnumerable<RoofType>> GetAllAsync();
        Task<RoofType> GetAsync(Guid id);
        Task<int> AddAsync(RoofType roofType);
        Task<int> UpdateAsync(RoofType roofType);
        Task<int> DeleteAsync(Guid id);
    }
}