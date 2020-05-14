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
    public class CoverTypesController : ControllerBase
    {
        private readonly ICoverTypeService _coverTypeService;

        public CoverTypesController(ICoverTypeService coverTypeService)
        {
            _coverTypeService = coverTypeService ?? throw new ArgumentNullException(nameof(coverTypeService));
        }

        // GET: api/CoverTypes
        [HttpGet]
        public async Task<ActionResult> GetCoverTypes()
        {
            CoverTypesViewModel model = await _coverTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.CoverTypes)).ConfigureAwait(true);
        }

        // GET: api/CoverTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCoverType(Guid id)
        {
            CoverTypeViewModel model = await _coverTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.CoverType)).ConfigureAwait(true);
        }

        // PUT: api/CoverTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoverType(Guid id, CoverType coverType)
        {
            if (coverType == null)
            {
                throw new ArgumentNullException(nameof(coverType));
            }

            if (id != coverType.ID)
            {
                return BadRequest();
            }

            CoverTypeViewModel model = new CoverTypeViewModel()
            {
                CoverType = coverType
            };

            await _coverTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/CoverTypes
        [HttpPost]
        public async Task<ActionResult> PostCoverType(CoverType coverType)
        {
            CoverTypeViewModel model = new CoverTypeViewModel()
            {
                CoverType = coverType
            };

            await _coverTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/CoverTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoverType(Guid id)
        {
            CoverTypeViewModel model = await _coverTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _coverTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
