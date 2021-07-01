using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IMaritalStatusService
    {
        Task<IEnumerable<MaritalStatus>> GetAllAsync();
        Task<MaritalStatusResponse> GetByIdAsync(Guid id);
        Task<MaritalStatusResponse> AddAsync(MaritalStatus maritalStatus);
        Task<MaritalStatusResponse> UpdateAsync(Guid id, MaritalStatus maritalStatus);
        Task<MaritalStatusResponse> DeleteAsync(Guid id);
        Task<MaritalStatusResponse> DeleteAsync(MaritalStatus maritalStatus);
    }
}