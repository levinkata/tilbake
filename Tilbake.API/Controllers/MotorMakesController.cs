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
    public class MotorMakesController : ControllerBase
    {
        private readonly IMotorMakeService _motorMakeService;

        public MotorMakesController(IMotorMakeService motorMakeService)
        {
            _motorMakeService = motorMakeService ?? throw new ArgumentNullException(nameof(motorMakeService));
        }

        // GET: api/MotorMakes
        [HttpGet]
        public async Task<IActionResult> GetMotorMakes()
        {
            MotorMakesViewModel model = await _motorMakeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.MotorMakes)).ConfigureAwait(true);
        }

        // GET: api/MotorMakes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMotorMake(Guid id)
        {
            MotorMakeViewModel model = await _motorMakeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.MotorMake)).ConfigureAwait(true);
        }

        // PUT: api/MotorMakes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorMake(Guid id, MotorMake motorMake)
        {
            if (motorMake == null)
            {
                throw new ArgumentNullException(nameof(motorMake));
            }

            if (id != motorMake.ID)
            {
                return BadRequest();
            }

            MotorMakeViewModel model = new MotorMakeViewModel()
            {
                MotorMake = motorMake
            };

            await _motorMakeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/MotorMakes
        [HttpPost]
        public async Task<IActionResult> PostMotorMake(MotorMake motorMake)
        {
            MotorMakeViewModel model = new MotorMakeViewModel()
            {
                MotorMake = motorMake
            };

            await _motorMakeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/MotorMakes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorMake(Guid id)
        {
            MotorMakeViewModel model = await _motorMakeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _motorMakeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
