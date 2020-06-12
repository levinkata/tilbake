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
    public class RiskItemsController : ControllerBase
    {
        private readonly IRiskItemService _riskItemService;

        public RiskItemsController(IRiskItemService riskItemService)
        {
            _riskItemService = riskItemService ?? throw new ArgumentNullException(nameof(riskItemService));
        }

        // GET: api/RiskItems
        [HttpGet]
        public async Task<IActionResult> GetRiskItems()
        {
            RiskItemsViewModel model = await _riskItemService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.RiskItems)).ConfigureAwait(true);
        }

        // GET: api/RiskItems/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRiskItem(Guid id)
        {
            RiskItemViewModel model = await _riskItemService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.RiskItem)).ConfigureAwait(true);
        }

        // PUT: api/RiskItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRiskItem(Guid id, RiskItem riskItem)
        {
            if (riskItem == null)
            {
                throw new ArgumentNullException(nameof(riskItem));
            }

            if (id != riskItem.ID)
            {
                return BadRequest();
            }

            RiskItemViewModel model = new RiskItemViewModel()
            {
                RiskItem = riskItem
            };

            await _riskItemService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/RiskItems
        [HttpPost]
        public async Task<IActionResult> PostRiskItem(RiskItem riskItem)
        {
            RiskItemViewModel model = new RiskItemViewModel()
            {
                RiskItem = riskItem
            };

            await _riskItemService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/RiskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRiskItem(Guid id)
        {
            RiskItemViewModel model = await _riskItemService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _riskItemService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
