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
    public class PolitikkRisksController : ControllerBase
    {
        private readonly IPolitikkRiskService _politikkRiskService;

        public PolitikkRisksController(IPolitikkRiskService politikkRiskService)
        {
            _politikkRiskService = politikkRiskService ?? throw new ArgumentNullException(nameof(politikkRiskService));
        }

        // GET: api/PolitikkRisks
        [HttpGet]
        public async Task<IActionResult> GetPolitikkRisks(Guid politikkId)
        {
            PolitikkRisksViewModel model = await _politikkRiskService.GetAllAsync(politikkId).ConfigureAwait(true);
            return await Task.Run(() => Ok(model.PolitikkRisks)).ConfigureAwait(true);
        }

        // GET: api/PolitikkRisks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolitikkRisk(Guid id)
        {
            PolitikkRiskViewModel model = await _politikkRiskService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.PolitikkRisk)).ConfigureAwait(true);
        }

        // PUT: api/PolitikkRisks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolitikkRisk(Guid id, PolitikkRisk politikkRisk)
        {
            if (politikkRisk == null)
            {
                throw new ArgumentNullException(nameof(politikkRisk));
            }

            if (id != politikkRisk.ID)
            {
                return BadRequest();
            }

            PolitikkRiskViewModel model = new PolitikkRiskViewModel()
            {
                PolitikkRisk = politikkRisk
            };

            await _politikkRiskService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/PolitikkRisks
        [HttpPost]
        public async Task<IActionResult> PostPolitikkRisk(PolitikkRisk politikkRisk)
        {
            PolitikkRiskViewModel model = new PolitikkRiskViewModel()
            {
                PolitikkRisk = politikkRisk
            };

            await _politikkRiskService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/PolitikkRisks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolitikkRisk(Guid id)
        {
            PolitikkRiskViewModel model = await _politikkRiskService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _politikkRiskService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
