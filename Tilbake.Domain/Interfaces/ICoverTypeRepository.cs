using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface ICoverTypeRepository
    {
        Task<IEnumerable<CoverType>> GetAllAsync();
        Task<CoverType> GetAsync(Guid id);
        Task<int> AddAsync(CoverType coverType);
        Task<int> UpdateAsync(CoverType coverType);
        Task<int> DeleteAsync(Guid id);
    }
}