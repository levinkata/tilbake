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
    public class PremiumTypesController : ControllerBase
    {
        private readonly IPremiumTypeService _premiumTypeService;

        public PremiumTypesController(IPremiumTypeService premiumTypeService)
        {
            _premiumTypeService = premiumTypeService ?? throw new ArgumentNullException(nameof(premiumTypeService));
        }

        // GET: api/PremiumTypes
        [HttpGet]
        public async Task<IActionResult> GetPremiumTypes()
        {
            PremiumTypesViewModel model = await _premiumTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.PremiumTypes)).ConfigureAwait(true);
        }

        // GET: api/PremiumTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPremiumType(Guid id)
        {
            PremiumTypeViewModel model = await _premiumTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.PremiumType)).ConfigureAwait(true);
        }

        // PUT: api/PremiumTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPremiumType(Guid id, PremiumType premiumType)
        {
            if (premiumType == null)
            {
                throw new ArgumentNullException(nameof(premiumType));
            }

            if (id != premiumType.ID)
            {
                return BadRequest();
            }

            PremiumTypeViewModel model = new PremiumTypeViewModel()
            {
                PremiumType = premiumType
            };

            await _premiumTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/PremiumTypes
        [HttpPost]
        public async Task<IActionResult> PostPremiumType(PremiumType premiumType)
        {
            PremiumTypeViewModel model = new PremiumTypeViewModel()
            {
                PremiumType = premiumType
            };

            await _premiumTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/PremiumTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremiumType(Guid id)
        {
            PremiumTypeViewModel model = await _premiumTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _premiumTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
