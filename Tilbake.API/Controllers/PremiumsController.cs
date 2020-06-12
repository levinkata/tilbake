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
    public class PremiumsController : ControllerBase
    {
        private readonly IPremiumService _premiumService;

        public PremiumsController(IPremiumService premiumService)
        {
            _premiumService = premiumService ?? throw new ArgumentNullException(nameof(premiumService));
        }

        // GET: api/Premiums
        [HttpGet]
        public async Task<IActionResult> GetPremiums()
        {
            PremiumsViewModel model = await _premiumService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Premiums)).ConfigureAwait(true);
        }

        // GET: api/Premiums/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPremium(Guid id)
        {
            PremiumViewModel model = await _premiumService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Premium)).ConfigureAwait(true);
        }

        // PUT: api/Premiums/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPremium(Guid id, Premium premium)
        {
            if (premium == null)
            {
                throw new ArgumentNullException(nameof(premium));
            }

            if (id != premium.ID)
            {
                return BadRequest();
            }

            PremiumViewModel model = new PremiumViewModel()
            {
                Premium = premium
            };

            await _premiumService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Premiums
        [HttpPost]
        public async Task<IActionResult> PostPremium(Premium premium)
        {
            PremiumViewModel model = new PremiumViewModel()
            {
                Premium = premium
            };

            await _premiumService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Premiums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePremium(Guid id)
        {
            PremiumViewModel model = await _premiumService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _premiumService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
