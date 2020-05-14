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
    public class RoofTypesController : ControllerBase
    {
        private readonly IRoofTypeService _roofTypeService;

        public RoofTypesController(IRoofTypeService roofTypeService)
        {
            _roofTypeService = roofTypeService ?? throw new ArgumentNullException(nameof(roofTypeService));
        }

        // GET: api/RoofTypes
        [HttpGet]
        public async Task<ActionResult> GetRoofTypes()
        {
            RoofTypesViewModel model = await _roofTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.RoofTypes)).ConfigureAwait(true);
        }

        // GET: api/RoofTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRoofType(Guid id)
        {
            RoofTypeViewModel model = await _roofTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.RoofType)).ConfigureAwait(true);
        }

        // PUT: api/RoofTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoofType(Guid id, RoofType roofType)
        {
            if (roofType == null)
            {
                throw new ArgumentNullException(nameof(roofType));
            }

            if (id != roofType.ID)
            {
                return BadRequest();
            }

            RoofTypeViewModel model = new RoofTypeViewModel()
            {
                RoofType = roofType
            };

            await _roofTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/RoofTypes
        [HttpPost]
        public async Task<ActionResult> PostRoofType(RoofType roofType)
        {
            RoofTypeViewModel model = new RoofTypeViewModel()
            {
                RoofType = roofType
            };

            await _roofTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/RoofTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoofType(Guid id)
        {
            RoofTypeViewModel model = await _roofTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _roofTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
