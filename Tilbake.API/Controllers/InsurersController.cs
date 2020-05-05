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
    public class InsurersController : ControllerBase
    {
        private readonly IInsurerService _insurerService;

        public InsurersController(IInsurerService insurerService)
        {
            _insurerService = insurerService ?? throw new ArgumentNullException(nameof(insurerService));
        }

        // GET: api/Insurers
        [HttpGet]
        public async Task<ActionResult<InsurersViewModel>> GetInsurers()
        {
            InsurersViewModel model = await _insurerService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Insurers)).ConfigureAwait(true);
        }

        // GET: api/Insurers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Insurer>> GetInsurer(Guid id)
        {
            InsurerViewModel model = await _insurerService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Insurer)).ConfigureAwait(true);
        }

        // PUT: api/Insurers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInsurer(Guid id, Insurer insurer)
        {
            if (insurer == null)
            {
                throw new ArgumentNullException(nameof(insurer));
            }

            if (id != insurer.ID)
            {
                return BadRequest();
            }

            InsurerViewModel model = new InsurerViewModel()
            {
                Insurer = insurer
            };

            await _insurerService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Insurers
        [HttpPost]
        public async Task<ActionResult<InsurerViewModel>> PostInsurer(Insurer insurer)
        {
            InsurerViewModel model = new InsurerViewModel()
            {
                Insurer = insurer
            };

            await _insurerService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Insurers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInsurer(Guid id)
        {
            InsurerViewModel model = await _insurerService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _insurerService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
