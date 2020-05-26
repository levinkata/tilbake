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
    public class KlientRisksController : ControllerBase
    {
        private readonly IKlientRiskService _klientRiskService;

        public KlientRisksController(IKlientRiskService klientRiskService)
        {
            _klientRiskService = klientRiskService ?? throw new ArgumentNullException(nameof(klientRiskService));
        }

        // GET: api/KlientRisks
        [HttpGet]
        public async Task<ActionResult> GetKlientRisks()
        {
            KlientRisksViewModel model = await _klientRiskService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.KlientRisks)).ConfigureAwait(true);
        }

        // GET: api/KlientRisks/Klient/5
        [HttpGet("Klient/{klientId}")]
        public async Task<ActionResult> GetKlientRiskByKlient(Guid klientId)
        {
            KlientRisksViewModel model = await _klientRiskService.GetKlientRisks(klientId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.KlientRisks)).ConfigureAwait(true);
        }

        // GET: api/KlientRisks/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetKlientRisk(Guid id)
        {
            KlientRiskViewModel model = await _klientRiskService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.KlientRisk)).ConfigureAwait(true);
        }

        // DELETE: api/KlientRisks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKlientRisk(Guid id)
        {
            KlientRiskViewModel model = await _klientRiskService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _klientRiskService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
