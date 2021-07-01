using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Domain.Models;

namespace Tilbake.Application.Interfaces
{
    public interface IOccupationService
    {
        Task<IEnumerable<Occupation>> GetAllAsync();
        Task<OccupationResponse> GetByIdAsync(Guid id);
        Task<OccupationResponse> AddAsync(Occupation occupation);
        Task<OccupationResponse> UpdateAsync(Guid id, Occupation occupation);
        Task<OccupationResponse> DeleteAsync(Guid id);
        Task<OccupationResponse> DeleteAsync(Occupation occupation);
    }
}