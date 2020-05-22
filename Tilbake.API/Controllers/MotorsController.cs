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
    public class MotorsController : ControllerBase
    {
        private readonly IMotorService _motorService;

        public MotorsController(IMotorService motorService)
        {
            _motorService = motorService ?? throw new ArgumentNullException(nameof(motorService));
        }

        // GET: api/Motors
        [HttpGet]
        public async Task<ActionResult> GetMotors()
        {
            MotorsViewModel model = await _motorService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Motors)).ConfigureAwait(true);
        }

        // GET: api/Motors/Klient/5
        [HttpGet("Klient/{klientId}")]
        public async Task<ActionResult> GetByBank(Guid klientId)
        {
            MotorsViewModel model = await _motorService.GetByKlientAsync(klientId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Motors)).ConfigureAwait(true);
        }

        // GET: api/Motors/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetMotor(Guid id)
        {
            MotorViewModel model = await _motorService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Motor)).ConfigureAwait(true);
        }

        // PUT: api/Motors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotor(Guid id, Motor motor)
        {
            if (motor == null)
            {
                throw new ArgumentNullException(nameof(motor));
            }

            if (id != motor.ID)
            {
                return BadRequest();
            }

            MotorViewModel model = new MotorViewModel()
            {
                Motor = motor
            };

            await _motorService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Motors/6
        [HttpPost("{klientId}")]
        public async Task<ActionResult> PostMotor(Guid klientId, Motor motor)
        {
            MotorViewModel model = new MotorViewModel()
            {
                KlientID = klientId,
                Motor = motor
            };

            await _motorService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Motors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotor(Guid id)
        {
            MotorViewModel model = await _motorService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _motorService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
