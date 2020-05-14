using System;
using System.Threading.Tasks;
using Tilbake.Application.ViewModels;

namespace Tilbake.Application.Interfaces
{
    public interface IIncidentService
    {
        Task<IncidentsViewModel> GetAllAsync();
        Task<IncidentViewModel> GetAsync(Guid id);
        Task<int> AddAsync(IncidentViewModel model);
        Task<int> UpdateAsync(IncidentViewModel model);
        Task<int> DeleteAsync(Guid id);
    }
}