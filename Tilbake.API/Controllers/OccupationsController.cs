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
    public class OccupationsController : ControllerBase
    {
        private readonly IOccupationService _occupationService;

        public OccupationsController(IOccupationService occupationService)
        {
            _occupationService = occupationService;
        }

        // GET: api/Occupations
        [HttpGet]
        public async Task<IActionResult> GetOccupations()
        {
            OccupationsViewModel model = await _occupationService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Occupations)).ConfigureAwait(true);
        }

        // GET: api/Occupations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOccupation(Guid id)
        {
            OccupationViewModel model = await _occupationService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Occupation)).ConfigureAwait(true);
        }

        // PUT: api/Occupations/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOccupation(Guid id, Occupation occupation)
        {
            if (occupation == null)
            {
                throw new ArgumentNullException(nameof(occupation));
            }

            if (id != occupation.ID)
            {
                return BadRequest();
            }

            OccupationViewModel model = new OccupationViewModel()
            {
                Occupation = occupation
            };

            await _occupationService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Occupations
        [HttpPost]
        public async Task<IActionResult> PostOccupation(Occupation occupation)
        {
            OccupationViewModel model = new OccupationViewModel()
            {
                Occupation = occupation
            };

            await _occupationService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Occupations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccupation(Guid id)
        {
            OccupationViewModel model = await _occupationService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _occupationService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
