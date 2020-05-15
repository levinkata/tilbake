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
    public class GlasssController : ControllerBase
    {
        private readonly IGlassService _glassService;

        public GlasssController(IGlassService glassService)
        {
            _glassService = glassService ?? throw new ArgumentNullException(nameof(glassService));
        }

        // GET: api/Glasss
        [HttpGet]
        public async Task<ActionResult> GetGlasss()
        {
            GlassesViewModel model = await _glassService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Glasses)).ConfigureAwait(true);
        }

        // GET: api/Glasss/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGlass(Guid id)
        {
            GlassViewModel model = await _glassService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Glass)).ConfigureAwait(true);
        }

        // PUT: api/Glasss/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGlass(Guid id, Glass glass)
        {
            if (glass == null)
            {
                throw new ArgumentNullException(nameof(glass));
            }

            if (id != glass.ID)
            {
                return BadRequest();
            }

            GlassViewModel model = new GlassViewModel()
            {
                Glass = glass
            };

            await _glassService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Glasss
        [HttpPost]
        public async Task<ActionResult> PostGlass(Guid klientId, Glass glass)
        {
            GlassViewModel model = new GlassViewModel()
            {
                KlientID = klientId,
                Glass = glass
            };

            await _glassService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Glasss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGlass(Guid id)
        {
            GlassViewModel model = await _glassService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _glassService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
