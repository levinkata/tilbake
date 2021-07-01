using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IMaritalStatusRepository
    {
        Task<IQueryable<MaritalStatus>> GetAllAsync();
        Task<MaritalStatus> GetByIdAsync(Guid id);
        Task<MaritalStatus> AddAsync(MaritalStatus maritalStatus);
        Task <IQueryable<MaritalStatus>> AddRangeAsync (IQueryable<MaritalStatus> maritalStatuss);
        Task<MaritalStatus> UpdateAsync(MaritalStatus maritalStatus);
        Task<MaritalStatus> DeleteAsync(Guid id);
        Task<MaritalStatus> DeleteAsync(MaritalStatus maritalStatus);
        Task<IQueryable<MaritalStatus>> DeleteRangeAsync(IQueryable<MaritalStatus> maritalStatuss);  
    }    
}