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
    public class MotorModelsController : ControllerBase
    {
        private readonly IMotorModelService _motorModelService;

        public MotorModelsController(IMotorModelService motorModelService)
        {
            _motorModelService = motorModelService ?? throw new ArgumentNullException(nameof(motorModelService));
        }

        // GET: api/MotorModels
        [HttpGet]
        public async Task<ActionResult> GetMotorModels()
        {
            MotorModelsViewModel model = await _motorModelService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.MotorModels)).ConfigureAwait(true);
        }

        // GET: api/MotorModels/MotorMake/5
        [HttpGet("MotorMake/{motorMakeId}")]
        public async Task<ActionResult> GetByMotorMake(Guid motorMakeId)
        {
            MotorModelsViewModel model = await _motorModelService.GetByMotorMakeAsync(motorMakeId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.MotorModels)).ConfigureAwait(true);
        }

        // GET: api/MotorModels/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult> GetMotorModel(Guid id)
        {
            MotorModelViewModel model = await _motorModelService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.MotorModel)).ConfigureAwait(true);
        }

        // PUT: api/MotorModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMotorModel(Guid id, MotorModel motorModel)
        {
            if (motorModel == null)
            {
                throw new ArgumentNullException(nameof(motorModel));
            }

            if (id != motorModel.ID)
            {
                return BadRequest();
            }

            MotorModelViewModel model = new MotorModelViewModel()
            {
                MotorModel = motorModel
            };

            await _motorModelService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/MotorModels
        [HttpPost]
        public async Task<ActionResult> PostMotorModel(MotorModel motorModel)
        {
            MotorModelViewModel model = new MotorModelViewModel()
            {
                MotorModel = motorModel
            };

            await _motorModelService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/MotorModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMotorModel(Guid id)
        {
            MotorModelViewModel model = await _motorModelService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _motorModelService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
