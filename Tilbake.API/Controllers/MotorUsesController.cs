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
    public class MotorUsesController : ControllerBase
    {
        private readonly IMotorUseService _motorUseService;

        public MotorUsesController(IMotorUseService motorUseService)
        {
            _motorUseService = motorUseService ?? throw new ArgumentNullException(nameof(motorUseService));
        }

        // GET: api/MotorUses
        [HttpGet]
        public async Task<ActionResult> GetMotorUses()
        {
            MotorUsesViewModel model = await _motorUseService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.MotorUses)).ConfigureAwait(true);
        }

        // GET: api/MotorUses/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMotorUse(Guid id)
        {
            MotorUseViewModel model = await _motorUseService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.MotorUse)).ConfigureAwait(true);
        }

        // PUT: api/MotorUses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorUse(Guid id, MotorUse motorUse)
        {
            if (motorUse == null)
            {
                throw new ArgumentNullException(nameof(motorUse));
            }

            if (id != motorUse.ID)
            {
                return BadRequest();
            }

            MotorUseViewModel model = new MotorUseViewModel()
            {
                MotorUse = motorUse
            };

            await _motorUseService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/MotorUses
        [HttpPost]
        public async Task<ActionResult> PostMotorUse(MotorUse motorUse)
        {
            MotorUseViewModel model = new MotorUseViewModel()
            {
                MotorUse = motorUse
            };

            await _motorUseService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/MotorUses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorUse(Guid id)
        {
            MotorUseViewModel model = await _motorUseService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _motorUseService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
