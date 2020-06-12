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
    public class ResidenceTypesController : ControllerBase
    {
        private readonly IResidenceTypeService _residenceTypeService;

        public ResidenceTypesController(IResidenceTypeService residenceTypeService)
        {
            _residenceTypeService = residenceTypeService ?? throw new ArgumentNullException(nameof(residenceTypeService));
        }

        // GET: api/ResidenceTypes
        [HttpGet]
        public async Task<IActionResult> GetResidenceTypes()
        {
            ResidenceTypesViewModel model = await _residenceTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.ResidenceTypes)).ConfigureAwait(true);
        }

        // GET: api/ResidenceTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetResidenceType(Guid id)
        {
            ResidenceTypeViewModel model = await _residenceTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.ResidenceType)).ConfigureAwait(true);
        }

        // PUT: api/ResidenceTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidenceType(Guid id, ResidenceType residenceType)
        {
            if (residenceType == null)
            {
                throw new ArgumentNullException(nameof(residenceType));
            }

            if (id != residenceType.ID)
            {
                return BadRequest();
            }

            ResidenceTypeViewModel model = new ResidenceTypeViewModel()
            {
                ResidenceType = residenceType
            };

            await _residenceTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/ResidenceTypes
        [HttpPost]
        public async Task<IActionResult> PostResidenceType(ResidenceType residenceType)
        {
            ResidenceTypeViewModel model = new ResidenceTypeViewModel()
            {
                ResidenceType = residenceType
            };

            await _residenceTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/ResidenceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResidenceType(Guid id)
        {
            ResidenceTypeViewModel model = await _residenceTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _residenceTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
