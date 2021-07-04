using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Infrastructure.Persistence.Interfaces
{
    public interface IMaritalStatusRepository
    {
        Task<IEnumerable<MaritalStatus>> GetAllAsync();
        Task<MaritalStatus> GetByIdAsync(Guid id);
        Task<MaritalStatus> AddAsync(MaritalStatus maritalStatus);
        Task <IEnumerable<MaritalStatus>> AddRangeAsync (IEnumerable<MaritalStatus> maritalStatuss);
        Task<MaritalStatus> UpdateAsync(MaritalStatus maritalStatus);
        Task<MaritalStatus> DeleteAsync(Guid id);
        Task<MaritalStatus> DeleteAsync(MaritalStatus maritalStatus);
        Task<IEnumerable<MaritalStatus>> DeleteRangeAsync(IEnumerable<MaritalStatus> maritalStatuss);  
    }    
}