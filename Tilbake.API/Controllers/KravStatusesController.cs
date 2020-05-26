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
    public class KravStatusesController : ControllerBase
    {
        private readonly IKravStatusService _kravStatusService;

        public KravStatusesController(IKravStatusService kravStatusService)
        {
            _kravStatusService = kravStatusService ?? throw new ArgumentNullException(nameof(kravStatusService));
        }

        // GET: api/KravStatuses
        [HttpGet]
        public async Task<ActionResult> GetKravStatuses()
        {
            KravStatusesViewModel model = await _kravStatusService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.KravStatuses)).ConfigureAwait(true);
        }

        // GET: api/KravStatuses/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetKravStatus(Guid id)
        {
            KravStatusViewModel model = await _kravStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.KravStatus)).ConfigureAwait(true);
        }

        // PUT: api/KravStatuses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKravStatus(Guid id, KravStatus kravStatus)
        {
            if (kravStatus == null)
            {
                throw new ArgumentNullException(nameof(kravStatus));
            }

            if (id != kravStatus.ID)
            {
                return BadRequest();
            }

            KravStatusViewModel model = new KravStatusViewModel()
            {
                KravStatus = kravStatus
            };

            await _kravStatusService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/KravStatuses
        [HttpPost]
        public async Task<ActionResult> PostKravStatus(KravStatus kravStatus)
        {
            KravStatusViewModel model = new KravStatusViewModel()
            {
                KravStatus = kravStatus
            };

            await _kravStatusService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/KravStatuses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKravStatus(Guid id)
        {
            KravStatusViewModel model = await _kravStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _kravStatusService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
