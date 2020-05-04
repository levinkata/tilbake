using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface ITitleRepository
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<Title> GetAsync(Guid id);
        Task<int> AddAsync(Title title);
        Task<int> UpdateAsync(Title title);
        Task<int> DeleteAsync(Guid id);
    }
}
