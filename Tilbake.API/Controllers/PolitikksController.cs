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
    public class PolitikksController : ControllerBase
    {
        private readonly IPolitikkService _politikkService;

        public PolitikksController(IPolitikkService politikkService)
        {
            _politikkService = politikkService ?? throw new ArgumentNullException(nameof(politikkService));
        }

        // GET: api/Politikks
        [HttpGet]
        public async Task<IActionResult> GetPolitikks()
        {
            PolitikksViewModel model = await _politikkService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Politikks)).ConfigureAwait(true);
        }

        // GET: api/Politikks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolitikk(Guid id)
        {
            PolitikkViewModel model = await _politikkService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Politikk)).ConfigureAwait(true);
        }

        // PUT: api/Politikks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolitikk(Guid id, Politikk politikk)
        {
            if (politikk == null)
            {
                throw new ArgumentNullException(nameof(politikk));
            }

            if (id != politikk.ID)
            {
                return BadRequest();
            }

            PolitikkViewModel model = new PolitikkViewModel()
            {
                Politikk = politikk
            };

            await _politikkService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Politikks
        [HttpPost]
        public async Task<IActionResult> PostPolitikk(Politikk politikk)
        {
            PolitikkViewModel model = new PolitikkViewModel()
            {
                Politikk = politikk
            };

            await _politikkService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Politikks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolitikk(Guid id)
        {
            PolitikkViewModel model = await _politikkService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _politikkService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
