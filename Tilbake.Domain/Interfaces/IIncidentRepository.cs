using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Domain.Models;

namespace Tilbake.Domain.Interfaces
{
    public interface IIncidentRepository
    {
        Task<IEnumerable<Incident>> GetAllAsync();
        Task<Incident> GetAsync(Guid id);
        Task<int> AddAsync(Incident incident);
        Task<int> UpdateAsync(Incident incident);
        Task<int> DeleteAsync(Guid id);
    }
}