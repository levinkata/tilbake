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
    public class RegionsController : ControllerBase
    {
        private readonly IRegionService _regionService;

        public RegionsController(IRegionService regionService)
        {
            _regionService = regionService ?? throw new ArgumentNullException(nameof(regionService));
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult> GetRegions()
        {
            RegionsViewModel model = await _regionService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Regions)).ConfigureAwait(true);
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetRegion(Guid id)
        {
            RegionViewModel model = await _regionService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Region)).ConfigureAwait(true);
        }

        // PUT: api/Regions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(Guid id, Region region)
        {
            if (region == null)
            {
                throw new ArgumentNullException(nameof(region));
            }

            if (id != region.ID)
            {
                return BadRequest();
            }

            RegionViewModel model = new RegionViewModel()
            {
                Region = region
            };

            await _regionService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Regions
        [HttpPost]
        public async Task<ActionResult> PostRegion(Region region)
        {
            RegionViewModel model = new RegionViewModel()
            {
                Region = region
            };

            await _regionService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(Guid id)
        {
            RegionViewModel model = await _regionService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _regionService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
