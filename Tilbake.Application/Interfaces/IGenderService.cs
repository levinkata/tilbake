using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IGenderService
    {
        Task<IEnumerable<Gender>> GetAllAsync();
        Task<GenderResponse> GetByIdAsync(Guid id);
        Task<GenderResponse> AddAsync(Gender gender);
        Task<GenderResponse> UpdateAsync(Guid id, Gender gender);
        Task<GenderResponse> DeleteAsync(Guid id);
        Task<GenderResponse> DeleteAsync(Gender gender);
    }
}