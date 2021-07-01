using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface ITitleRepository
    {
        Task<IQueryable<Title>> GetAllAsync();
        Task<Title> GetByIdAsync(Guid id);
        Task<Title> AddAsync(Title title);
        Task <IQueryable<Title>> AddRangeAsync (IQueryable<Title> titles);
        Task<Title> UpdateAsync(Title title);
        Task<Title> DeleteAsync(Guid id);
        Task<Title> DeleteAsync(Title title);
        Task<IQueryable<Title>> DeleteRangeAsync(IQueryable<Title> titles);  
    }    
}