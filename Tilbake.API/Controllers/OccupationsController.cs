using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tilbake.API.Resources;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]    
    public class OccupationsController : ControllerBase
    {
        private readonly IOccupationService _occupationService;
        private readonly IMapper _mapper;

        public OccupationsController(IOccupationService occupationService, IMapper mapper)
        {
            _occupationService = occupationService ?? throw new ArgumentNullException(nameof(occupationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all occupations.
        /// </summary>
        /// <returns>List of occupations.</returns>
        /// 
        // GET: api/Occupations
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OccupationResource>), 200)]
        public async Task<IEnumerable<OccupationResource>> GetAllAsync()
        {
            var result = await _occupationService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Occupation>, IEnumerable<OccupationResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing occupation according to an identifier..
        /// </summary>
        /// <param name="id">Occupation identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Occupations/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OccupationResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _occupationService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
            return Ok(occupationResource);
        }

        /// <summary>
        /// Updates an existing occupation according to an identifier.
        /// </summary>
        /// <param name="id">Occupation identifier.</param>
        /// <param name="resource">Updated occupation data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Occupations/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(OccupationResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] OccupationResource occupationResource)
        {
            if (occupationResource == null)
            {
                throw new ArgumentNullException(nameof(occupationResource));
            }

            Occupation occupation = _mapper.Map<OccupationResource, Occupation>(occupationResource);

            var result = await _occupationService.UpdateAsync(id, occupation).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
            return Ok(occupationResource);
        }

        /// <summary>
        /// Saves a new occupation.
        /// </summary>
        /// <param name="resource">Occupation data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Occupations
        [HttpPost]
        [ProducesResponseType(typeof(OccupationResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] OccupationResource occupationResource)
        {
            if (occupationResource == null)
            {
                throw new ArgumentNullException(nameof(occupationResource));
            }

            Occupation occupation = _mapper.Map<OccupationResource, Occupation>(occupationResource);

            var result = await _occupationService.AddAsync(occupation).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
            return Ok(occupationResource);
        }

        /// <summary>
        /// Deletes a given occupation according to an identifier.
        /// </summary>
        /// <param name="id">Occupation identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Occupations/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(OccupationResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _occupationService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var occupationResource = _mapper.Map<Occupation, OccupationResource>(result.Resource);
            return Ok(occupationResource);
        }
    }
}