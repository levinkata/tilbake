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
        Task AddAsync(Title title);
        void UpdateAsync(Title title);
        void DeleteAsync(Title title);
    }
}
