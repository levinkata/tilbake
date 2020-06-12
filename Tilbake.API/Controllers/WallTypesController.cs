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
    public class WallTypesController : ControllerBase
    {
        private readonly IWallTypeService _wallTypeService;

        public WallTypesController(IWallTypeService wallTypeService)
        {
            _wallTypeService = wallTypeService ?? throw new ArgumentNullException(nameof(wallTypeService));
        }

        // GET: api/WallTypes
        [HttpGet]
        public async Task<IActionResult> GetWallTypes()
        {
            WallTypesViewModel model = await _wallTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.WallTypes)).ConfigureAwait(true);
        }

        // GET: api/WallTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWallType(Guid id)
        {
            WallTypeViewModel model = await _wallTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.WallType)).ConfigureAwait(true);
        }

        // PUT: api/WallTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWallType(Guid id, WallType wallType)
        {
            if (wallType == null)
            {
                throw new ArgumentNullException(nameof(wallType));
            }

            if (id != wallType.ID)
            {
                return BadRequest();
            }

            WallTypeViewModel model = new WallTypeViewModel()
            {
                WallType = wallType
            };

            await _wallTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/WallTypes
        [HttpPost]
        public async Task<IActionResult> PostWallType(WallType wallType)
        {
            WallTypeViewModel model = new WallTypeViewModel()
            {
                WallType = wallType
            };

            await _wallTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/WallTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWallType(Guid id)
        {
            WallTypeViewModel model = await _wallTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _wallTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
