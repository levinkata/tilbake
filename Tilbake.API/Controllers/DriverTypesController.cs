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
    public class DriverTypesController : ControllerBase
    {
        private readonly IDriverTypeService _driverTypeService;

        public DriverTypesController(IDriverTypeService driverTypeService)
        {
            _driverTypeService = driverTypeService ?? throw new ArgumentNullException(nameof(driverTypeService));
        }

        // GET: api/DriverTypes
        [HttpGet]
        public async Task<IActionResult> GetDriverTypes()
        {
            DriverTypesViewModel model = await _driverTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.DriverTypes)).ConfigureAwait(true);
        }

        // GET: api/DriverTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverType(Guid id)
        {
            DriverTypeViewModel model = await _driverTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.DriverType)).ConfigureAwait(true);
        }

        // PUT: api/DriverTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverType(Guid id, DriverType driverType)
        {
            if (driverType == null)
            {
                throw new ArgumentNullException(nameof(driverType));
            }

            if (id != driverType.ID)
            {
                return BadRequest();
            }

            DriverTypeViewModel model = new DriverTypeViewModel()
            {
                DriverType = driverType
            };

            await _driverTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/DriverTypes
        [HttpPost]
        public async Task<IActionResult> PostDriverType(DriverType driverType)
        {
            DriverTypeViewModel model = new DriverTypeViewModel()
            {
                DriverType = driverType
            };

            await _driverTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/DriverTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverType(Guid id)
        {
            DriverTypeViewModel model = await _driverTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _driverTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
