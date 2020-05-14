using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Interfaces;

namespace Tilbake.Application.Services
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _incidentRepository;

        public IncidentService(IIncidentRepository incidentRepository)
        {
            _incidentRepository = incidentRepository;
        }
        
        public async Task<int> AddAsync(IncidentViewModel model)
        {
            return await Task.Run(() => _incidentRepository.AddAsync(model.Incident)).ConfigureAwait(true);
        }

        public async Task<int> DeleteAsync(Guid id)
        {
            return await Task.Run(() => _incidentRepository.DeleteAsync(id)).ConfigureAwait(true);
        }

        public async Task<IncidentsViewModel> GetAllAsync()
        {
            return new IncidentsViewModel()
            {
                Incidents = await Task.Run(() => _incidentRepository.GetAllAsync()).ConfigureAwait(true)
            };
        }

        public async Task<IncidentViewModel> GetAsync(Guid id)
        {
            return new IncidentViewModel()
            {
                Incident = await Task.Run(() => _incidentRepository.GetAsync(id)).ConfigureAwait(true)
            };
        }

        public async Task<int> UpdateAsync(IncidentViewModel model)
        {
            return await Task.Run(() => _incidentRepository.UpdateAsync(model.Incident)).ConfigureAwait(true);
        }
        
    }
}