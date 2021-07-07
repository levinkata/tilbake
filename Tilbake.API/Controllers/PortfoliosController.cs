using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]    
    public class PortfoliosController : ControllerBase
    {
        private readonly IPortfolioService _portfolioService;

        public PortfoliosController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService ?? throw new ArgumentNullException(nameof(portfolioService));
        }

        /// <summary>
        /// Lists all portfolios.
        /// </summary>
        /// <returns>List of portfolios.</returns>
        /// 
        // GET: api/Portfolios
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PortfolioResource>), 200)]
        public async Task<IEnumerable<PortfolioResource>> GetAllAsync()
        {
            var resources = await _portfolioService.GetAllAsync().ConfigureAwait(true);
            return resources;
        }

        /// <summary>
        /// Lists an existing portfolio according to an identifier..
        /// </summary>
        /// <param name="id">Portfolio identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Portfolios/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PortfolioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var portfolioResponse = await _portfolioService.GetByIdAsync(id).ConfigureAwait(true);
            return Ok(portfolioResponse);
        }

        /// <summary>
        /// Updates an existing portfolio according to an identifier.
        /// </summary>
        /// <param name="id">Portfolio identifier.</param>
        /// <param name="resource">Updated portfolio data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Portfolios/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PortfolioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] PortfolioResource portfolioResource)
        {
            if (portfolioResource == null)
            {
                throw new ArgumentNullException(nameof(portfolioResource));
            }

            portfolioResource.Id = id;
            var resource = await _portfolioService.UpdateAsync(portfolioResource).ConfigureAwait(true);

            return Ok(resource);
        }

        /// <summary>
        /// Saves a new portfolio.
        /// </summary>
        /// <param name="resource">Portfolio data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Portfolios
        [HttpPost]
        [ProducesResponseType(typeof(PortfolioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] PortfolioSaveResource portfolioSaveResource)
        {
            if (portfolioSaveResource == null)
            {
                throw new ArgumentNullException(nameof(portfolioSaveResource));
            }


            var resource = await _portfolioService.AddAsync(portfolioSaveResource).ConfigureAwait(true);
            return Ok(resource);
        }

        /// <summary>
        /// Deletes a given portfolio according to an identifier.
        /// </summary>
        /// <param name="id">Portfolio identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Portfolios/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PortfolioResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var portfolioResponse = await _portfolioService.DeleteAsync(id).ConfigureAwait(true);
            return Ok(portfolioResponse);
        }
    }
}