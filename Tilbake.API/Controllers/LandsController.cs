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
    public class LandsController : ControllerBase
    {
        private readonly ILandService _landService;

        public LandsController(ILandService landService)
        {
            _landService = landService;
        }

        // GET: api/Lands
        [HttpGet]
        public async Task<IActionResult> GetLands()
        {
            LandsViewModel model = await _landService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Lands)).ConfigureAwait(true);
        }

        // GET: api/Lands/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLand(Guid id)
        {
            LandViewModel model = await _landService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Land)).ConfigureAwait(true);
        }

        // PUT: api/Lands/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLand(Guid id, Land land)
        {
            if (land == null)
            {
                throw new ArgumentNullException(nameof(land));
            }

            if (id != land.ID)
            {
                return BadRequest();
            }

            LandViewModel model = new LandViewModel()
            {
                Land = land
            };

            await _landService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Lands
        [HttpPost]
        public async Task<ActionResult> PostLand(Land land)
        {
            LandViewModel model = new LandViewModel()
            {
                Land = land
            };

            await _landService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Lands/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLand(Guid id)
        {
            LandViewModel model = await _landService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _landService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
