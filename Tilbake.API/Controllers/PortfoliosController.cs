using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfoliosController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService ?? throw new ArgumentNullException(nameof(portfolioService));
        }

        // GET: api/Portfolios
        [HttpGet]
        public async Task<ActionResult> GetPortfolios()
        {
            PortfoliosViewModel model = await _portfolioService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Portfolios)).ConfigureAwait(true);
        }

        // GET: api/Portfolios/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetPortfolio(Guid id)
        {
            PortfolioViewModel model = await _portfolioService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Portfolio)).ConfigureAwait(true);
        }

        // PUT: api/Portfolios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPortfolio(Guid id, Portfolio portfolio)
        {
            if (portfolio == null)
            {
                throw new ArgumentNullException(nameof(portfolio));
            }

            if (id != portfolio.ID)
            {
                return BadRequest();
            }

            PortfolioViewModel model = new PortfolioViewModel()
            {
                Portfolio = portfolio
            };

            await _portfolioService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Portfolios
        [HttpPost]
        public async Task<ActionResult> PostPortfolio(Portfolio portfolio)
        {
            PortfolioViewModel model = new PortfolioViewModel()
            {
                Portfolio = portfolio
            };

            await _portfolioService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Portfolios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePortfolio(Guid id)
        {
            PortfolioViewModel model = await _portfolioService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _portfolioService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
