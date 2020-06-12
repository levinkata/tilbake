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
    public class PolitikkTypesController : ControllerBase
    {
        private readonly IPolitikkTypeService _politikkTypeService;

        public PolitikkTypesController(IPolitikkTypeService politikkTypeService)
        {
            _politikkTypeService = politikkTypeService ?? throw new ArgumentNullException(nameof(politikkTypeService));
        }

        // GET: api/PolitikkTypes
        [HttpGet]
        public async Task<IActionResult> GetPolitikkTypes()
        {
            PolitikkTypesViewModel model = await _politikkTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.PolitikkTypes)).ConfigureAwait(true);
        }

        // GET: api/PolitikkTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPolitikkType(Guid id)
        {
            PolitikkTypeViewModel model = await _politikkTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.PolitikkType)).ConfigureAwait(true);
        }

        // PUT: api/PolitikkTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPolitikkType(Guid id, PolitikkType politikkType)
        {
            if (politikkType == null)
            {
                throw new ArgumentNullException(nameof(politikkType));
            }

            if (id != politikkType.ID)
            {
                return BadRequest();
            }

            PolitikkTypeViewModel model = new PolitikkTypeViewModel()
            {
                PolitikkType = politikkType
            };

            await _politikkTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/PolitikkTypes
        [HttpPost]
        public async Task<IActionResult> PostPolitikkType(PolitikkType politikkType)
        {
            PolitikkTypeViewModel model = new PolitikkTypeViewModel()
            {
                PolitikkType = politikkType
            };

            await _politikkTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/PolitikkTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePolitikkType(Guid id)
        {
            PolitikkTypeViewModel model = await _politikkTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _politikkTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
