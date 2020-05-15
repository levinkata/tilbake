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
    public class QuoteStatusesController : ControllerBase
    {
        private readonly IQuoteStatusService _quoteStatusService;

        public QuoteStatusesController(IQuoteStatusService quoteStatusService)
        {
            _quoteStatusService = quoteStatusService;
        }

        // GET: api/QuoteStatuss
        [HttpGet]
        public async Task<IActionResult> GetQuoteStatuss()
        {
            QuoteStatusesViewModel model = await _quoteStatusService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.QuoteStatuses)).ConfigureAwait(true);
        }

        // GET: api/QuoteStatuss/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuoteStatus(Guid id)
        {
            QuoteStatusViewModel model = await _quoteStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.QuoteStatus)).ConfigureAwait(true);
        }

        // PUT: api/QuoteStatuss/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuoteStatus(Guid id, QuoteStatus quoteStatus)
        {
            if (quoteStatus == null)
            {
                throw new ArgumentNullException(nameof(quoteStatus));
            }

            if (id != quoteStatus.ID)
            {
                return BadRequest();
            }

            QuoteStatusViewModel model = new QuoteStatusViewModel()
            {
                QuoteStatus = quoteStatus
            };

            await _quoteStatusService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/QuoteStatuss
        [HttpPost]
        public async Task<ActionResult> PostQuoteStatus(QuoteStatus quoteStatus)
        {
            QuoteStatusViewModel model = new QuoteStatusViewModel()
            {
                QuoteStatus = quoteStatus
            };

            await _quoteStatusService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/QuoteStatuss/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuoteStatus(Guid id)
        {
            QuoteStatusViewModel model = await _quoteStatusService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _quoteStatusService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
