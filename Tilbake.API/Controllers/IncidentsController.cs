using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService ?? throw new ArgumentNullException(nameof(incidentService));
        }

        // GET: api/Incidents
        [HttpGet]
        public async Task<IActionResult> GetIncidents()
        {
            IncidentsViewModel model = await _incidentService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Incidents)).ConfigureAwait(true);
        }

        // GET: api/Incidents/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIncident(Guid id)
        {
            IncidentViewModel model = await _incidentService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Incident)).ConfigureAwait(true);
        }

        // PUT: api/Incidents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncident(Guid id, Incident incident)
        {
            if (incident == null)
            {
                throw new ArgumentNullException(nameof(incident));
            }

            if (id != incident.ID)
            {
                return BadRequest();
            }

            IncidentViewModel model = new IncidentViewModel()
            {
                Incident = incident
            };

            await _incidentService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Incidents
        [HttpPost]
        public async Task<IActionResult> PostIncident(Incident incident)
        {
            IncidentViewModel model = new IncidentViewModel()
            {
                Incident = incident
            };

            await _incidentService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Incidents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncident(Guid id)
        {
            IncidentViewModel model = await _incidentService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _incidentService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
