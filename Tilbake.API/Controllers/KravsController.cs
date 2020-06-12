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
    public class KravsController : ControllerBase
    {
        private readonly IKravService _kravService;

        public KravsController(IKravService kravService)
        {
            _kravService = kravService ?? throw new ArgumentNullException(nameof(kravService));
        }

        // GET: api/Kravs
        [HttpGet]
        public async Task<IActionResult> GetKravs()
        {
            KravsViewModel model = await _kravService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Kravs)).ConfigureAwait(true);
        }

        // GET: api/Kravs/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKrav(int id)
        {
            KravViewModel model = await _kravService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Krav)).ConfigureAwait(true);
        }

        // PUT: api/Kravs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKrav(int id, Krav krav)
        {
            if (krav == null)
            {
                throw new ArgumentNullException(nameof(krav));
            }

            if (id != krav.KravNumber)
            {
                return BadRequest();
            }

            KravViewModel model = new KravViewModel()
            {
                Krav = krav
            };

            await _kravService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Kravs
        [HttpPost]
        public async Task<IActionResult> PostKrav(Krav krav)
        {
            KravViewModel model = new KravViewModel()
            {
                Krav = krav
            };

            await _kravService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Kravs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKrav(int id)
        {
            KravViewModel model = await _kravService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _kravService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
