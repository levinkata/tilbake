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
    public class AllRisksController : ControllerBase
    {
        private readonly IAllRiskService _allRiskService;

        public AllRisksController(IAllRiskService allRiskService)
        {
            _allRiskService = allRiskService ?? throw new ArgumentNullException(nameof(allRiskService));
        }

        // GET: api/AllRisks
        [HttpGet]
        public async Task<ActionResult> GetAllRisks()
        {
            AllRisksViewModel model = await _allRiskService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.AllRisks)).ConfigureAwait(true);
        }

        // GET: api/AllRisks/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAllRisk(Guid id)
        {
            AllRiskViewModel model = await _allRiskService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.AllRisk)).ConfigureAwait(true);
        }

        // PUT: api/AllRisks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAllRisk(Guid id, AllRisk allRisk)
        {
            if (allRisk == null)
            {
                throw new ArgumentNullException(nameof(allRisk));
            }

            if (id != allRisk.ID)
            {
                return BadRequest();
            }

            AllRiskViewModel model = new AllRiskViewModel()
            {
                AllRisk = allRisk
            };

            await _allRiskService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/AllRisks
        [HttpPost]
        public async Task<ActionResult> PostAllRisk(Guid klientId, AllRisk allRisk)
        {
            AllRiskViewModel model = new AllRiskViewModel()
            {
                KlientID = klientId,
                AllRisk = allRisk
            };

            await _allRiskService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/AllRisks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAllRisk(Guid id)
        {
            AllRiskViewModel model = await _allRiskService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _allRiskService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
