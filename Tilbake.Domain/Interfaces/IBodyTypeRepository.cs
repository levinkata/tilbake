using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IBodyTypeRepository
    {
        Task<IEnumerable<BodyType>> GetAllAsync();
        Task<BodyType> GetAsync(Guid id);
        Task<int> AddAsync(BodyType bodyType);
        Task<int> UpdateAsync(BodyType bodyType);
        Task<int> DeleteAsync(Guid id);
    }
}
