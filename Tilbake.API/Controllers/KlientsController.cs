using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.API.Resources;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class KlientsController : ControllerBase
    {
        private readonly IKlientService _klientService;
        private readonly IMapper _mapper;

        public KlientsController(IKlientService klientService, IMapper mapper)
        {
            _klientService = klientService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all existing klients.
        /// </summary>
        /// <returns>List of klients.</returns>
        // GET: api/Klients
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<KlientResource>), 200)]
        public async Task<IEnumerable<KlientResource>> GetAsync()
        {
            var klients = await _klientService.GetAllAsync().ConfigureAwait(true);

            var resources = _mapper.Map<IEnumerable<Klient>, IEnumerable<KlientResource>>(klients);
            return resources;
        }

        // GET: api/Klients/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(KlientResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _klientService.GetAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var klientResource = _mapper.Map<Klient, KlientResource>(result.Resource);
            return Ok(klientResource);
        }

        // GET: api/Klients/IdNumber/5
        [HttpGet("IdNumber/{IdNumber}")]
        public async Task<IActionResult> GetByIdNumber(string IdNumber)
        {
            var result = await _klientService.GetByIdNumberAsync(IdNumber).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var klientResource = _mapper.Map<Klient, KlientResource>(result.Resource);
            return Ok(klientResource);
        }

        /// <summary>
        /// Updates an existing klient according to an identifier.
        /// </summary>
        /// <param name="id">Klient identifier.</param>
        /// <param name="resource">Klient data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Klients/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(KlientResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveKlientResource resource)
        {
            var klient = _mapper.Map<SaveKlientResource, Klient>(resource);
            var result = await _klientService.UpdateAsync(id, klient).ConfigureAwait(true);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var klientResource = _mapper.Map<Klient, KlientResource>(result.Resource);
            return Ok(klientResource);
        }

        /// <summary>
        /// Saves a new klient.
        /// </summary>
        /// <param name="resource">Klient data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Klients
        [HttpPost]
        [ProducesResponseType(typeof(KlientResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync(Guid portfolioId, [FromBody] SaveKlientResource resource)
        {
            var klient = _mapper.Map<SaveKlientResource, Klient>(resource);
            var result = await _klientService.AddToPortfolio(portfolioId, klient).ConfigureAwait(true);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var klientResource = _mapper.Map<Klient, KlientResource>(result.Resource);
            return Ok(klientResource);
        }

        /// <summary>
        /// Deletes a given klient according to an identifier.
        /// </summary>
        /// <param name="id">Klient identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Klients/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(KlientResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _klientService.DeleteAsync(id).ConfigureAwait(true);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var klientResource = _mapper.Map<Klient, KlientResource>(result.Resource);
            return Ok(klientResource);
        }
    }
}
