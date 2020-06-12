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
    public class HousesController : ControllerBase
    {
        private readonly IHouseService _houseService;

        public HousesController(IHouseService houseService)
        {
            _houseService = houseService ?? throw new ArgumentNullException(nameof(houseService));
        }

        // GET: api/Houses
        [HttpGet]
        public async Task<IActionResult> GetHouses()
        {
            HousesViewModel model = await _houseService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Houses)).ConfigureAwait(true);
        }

        // GET: api/Houses/Klient/5
        [HttpGet("Klient/{klientId}")]
        public async Task<IActionResult> GetByKlient(Guid klientId)
        {
            HousesViewModel model = await _houseService.GetByKlientAsync(klientId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Houses)).ConfigureAwait(true);
        }

        // GET: api/Houses/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHouse(Guid id)
        {
            HouseViewModel model = await _houseService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.House)).ConfigureAwait(true);
        }

        // PUT: api/Houses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHouse(Guid id, House house)
        {
            if (house == null)
            {
                throw new ArgumentNullException(nameof(house));
            }

            if (id != house.ID)
            {
                return BadRequest();
            }

            HouseViewModel model = new HouseViewModel()
            {
                House = house
            };

            await _houseService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Houses/6
        [HttpPost]
        [HttpPost("{klientId}")]
        public async Task<IActionResult> PostHouse(Guid klientId, House house)
        {
            HouseViewModel model = new HouseViewModel()
            {
                KlientID = klientId,
                House = house
            };

            await _houseService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Houses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHouse(Guid id)
        {
            HouseViewModel model = await _houseService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _houseService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
