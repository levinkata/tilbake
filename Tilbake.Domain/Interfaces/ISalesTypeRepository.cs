using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface ISalesTypeRepository
    {
        Task<IEnumerable<SalesType>> GetAllAsync();
        Task<SalesType> GetAsync(Guid id);
        Task<int> AddAsync(SalesType salesType);
        Task<int> UpdateAsync(SalesType salesType);
        Task<int> DeleteAsync(Guid id);
    }
}
