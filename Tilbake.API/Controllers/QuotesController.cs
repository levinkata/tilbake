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
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService ?? throw new ArgumentNullException(nameof(quoteService));
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<QuotesViewModel>> GetQuotes()
        {
            QuotesViewModel model = await _quoteService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Quotes)).ConfigureAwait(true);
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(Guid id)
        {
            QuoteViewModel model = await _quoteService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Quote)).ConfigureAwait(true);
        }

        // PUT: api/Quotes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(Guid id, Quote quote)
        {
            if (quote == null)
            {
                throw new ArgumentNullException(nameof(quote));
            }

            if (id != quote.ID)
            {
                return BadRequest();
            }

            QuoteViewModel model = new QuoteViewModel()
            {
                Quote = quote
            };

            await _quoteService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Quotes
        [HttpPost]
        public async Task<ActionResult<QuoteViewModel>> PostQuote(Quote quote)
        {
            QuoteViewModel model = new QuoteViewModel()
            {
                Quote = quote
            };

            await _quoteService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Quotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(Guid id)
        {
            QuoteViewModel model = await _quoteService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _quoteService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
