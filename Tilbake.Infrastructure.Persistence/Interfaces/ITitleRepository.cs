using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface ITitleRepository
    {
        Task<IEnumerable<Title>> GetAllAsync();
        Task<Title> GetByIdAsync(Guid id);
        Task<Title> AddAsync(Title title);
        Task <IEnumerable<Title>> AddRangeAsync (IEnumerable<Title> titles);
        Task<Title> UpdateAsync(Title title);
        Task<Title> DeleteAsync(Guid id);
        Task<Title> DeleteAsync(Title title);
        Task<IEnumerable<Title>> DeleteRangeAsync(IEnumerable<Title> titles);  
    }    
}