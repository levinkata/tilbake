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
    public class SalesTypesController : ControllerBase
    {
        private readonly ISalesTypeService _salesTypeService;

        public SalesTypesController(ISalesTypeService salesTypeService)
        {
            _salesTypeService = salesTypeService ?? throw new ArgumentNullException(nameof(salesTypeService));
        }

        // GET: api/SalesTypes
        [HttpGet]
        public async Task<IActionResult> GetSalesTypes()
        {
            SalesTypesViewModel model = await _salesTypeService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.SalesTypes)).ConfigureAwait(true);
        }

        // GET: api/SalesTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSalesType(Guid id)
        {
            SalesTypeViewModel model = await _salesTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.SalesType)).ConfigureAwait(true);
        }

        // PUT: api/SalesTypes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSalesType(Guid id, SalesType salesType)
        {
            if (salesType == null)
            {
                throw new ArgumentNullException(nameof(salesType));
            }

            if (id != salesType.ID)
            {
                return BadRequest();
            }

            SalesTypeViewModel model = new SalesTypeViewModel()
            {
                SalesType = salesType
            };

            await _salesTypeService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/SalesTypes
        [HttpPost]
        public async Task<IActionResult> PostSalesType(SalesType salesType)
        {
            SalesTypeViewModel model = new SalesTypeViewModel()
            {
                SalesType = salesType
            };

            await _salesTypeService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/SalesTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalesType(Guid id)
        {
            SalesTypeViewModel model = await _salesTypeService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _salesTypeService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
