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
    public class BodyTypesController : ControllerBase
    {
        private readonly IBodyTypeService _bodyTypeService;

        public BodyTypesController(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService ?? throw new ArgumentNullException(nameof(bodyTypeService));
        }

        // GET: api/BodyTypes
        [HttpGet]
        public async Task<ActionResult<BodyTypesViewModel>> GetBodyTypes()
        {
            BodyTypesViewModel model = await _bodyTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.BodyTypes)).ConfigureAwait(true);
        }

        // GET: api/BodyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BodyType>> GetBodyType(Guid id)
        {
            BodyTypeViewModel model = await _bodyTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.BodyType)).ConfigureAwait(true);
        }

        // PUT: api/BodyTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBodyType(Guid id, BodyType bodyType)
        {
            if (bodyType == null)
            {
                throw new ArgumentNullException(nameof(bodyType));
            }

            if (id != bodyType.ID)
            {
                return BadRequest();
            }

            BodyTypeViewModel model = new BodyTypeViewModel()
            {
                BodyType = bodyType
            };

            await _bodyTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/BodyTypes
        [HttpPost]
        public async Task<ActionResult<BodyTypeViewModel>> PostBodyType(BodyType bodyType)
        {
            BodyTypeViewModel model = new BodyTypeViewModel()
            {
                BodyType = bodyType
            };

            await _bodyTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/BodyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBodyType(Guid id)
        {
            BodyTypeViewModel model = await _bodyTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _bodyTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
