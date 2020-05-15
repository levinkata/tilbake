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
    public class PolitikkStatusesController : ControllerBase
    {
        private readonly IPolitikkStatusService _politikkStatusService;

        public PolitikkStatusesController(IPolitikkStatusService politikkStatusService)
        {
            _politikkStatusService = politikkStatusService ?? throw new ArgumentNullException(nameof(politikkStatusService));
        }

        // GET: api/PolitikkStatuss
        [HttpGet]
        public async Task<ActionResult> GetPolitikkStatuss()
        {
            PolitikkStatusesViewModel model = await _politikkStatusService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.PolitikkStatuses)).ConfigureAwait(true);
        }

        // GET: api/PolitikkStatuss/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPolitikkStatus(Guid id)
        {
            PolitikkStatusViewModel model = await _politikkStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.PolitikkStatus)).ConfigureAwait(true);
        }

        // PUT: api/PolitikkStatuss/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolitikkStatus(Guid id, PolitikkStatus politikkStatus)
        {
            if (politikkStatus == null)
            {
                throw new ArgumentNullException(nameof(politikkStatus));
            }

            if (id != politikkStatus.ID)
            {
                return BadRequest();
            }

            PolitikkStatusViewModel model = new PolitikkStatusViewModel()
            {
                PolitikkStatus = politikkStatus
            };

            await _politikkStatusService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/PolitikkStatuss
        [HttpPost]
        public async Task<ActionResult> PostPolitikkStatus(PolitikkStatus politikkStatus)
        {
            PolitikkStatusViewModel model = new PolitikkStatusViewModel()
            {
                PolitikkStatus = politikkStatus
            };

            await _politikkStatusService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/PolitikkStatuss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolitikkStatus(Guid id)
        {
            PolitikkStatusViewModel model = await _politikkStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _politikkStatusService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
