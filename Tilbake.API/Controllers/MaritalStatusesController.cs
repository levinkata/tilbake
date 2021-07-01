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
    public class MaritalStatusesController : ControllerBase
    {
        private readonly IMaritalStatusService _maritalStatusService;
        private readonly IMapper _mapper;

        public MaritalStatusesController(IMaritalStatusService maritalStatusService, IMapper mapper)
        {
            _maritalStatusService = maritalStatusService ?? throw new ArgumentNullException(nameof(maritalStatusService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all maritalStatuses.
        /// </summary>
        /// <returns>List of maritalStatuses.</returns>
        /// 
        // GET: api/MaritalStatuses
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MaritalStatusResource>), 200)]
        public async Task<IEnumerable<MaritalStatusResource>> GetAllAsync()
        {
            var result = await _maritalStatusService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<MaritalStatus>, IEnumerable<MaritalStatusResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing maritalStatus according to an identifier..
        /// </summary>
        /// <param name="id">MaritalStatus identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/MaritalStatuses/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(MaritalStatusResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _maritalStatusService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var maritalStatusResource = _mapper.Map<MaritalStatus, MaritalStatusResource>(result.Resource);
            return Ok(maritalStatusResource);
        }

        /// <summary>
        /// Updates an existing maritalStatus according to an identifier.
        /// </summary>
        /// <param name="id">MaritalStatus identifier.</param>
        /// <param name="resource">Updated maritalStatus data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/MaritalStatuses/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(MaritalStatusResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] MaritalStatusResource maritalStatusResource)
        {
            if (maritalStatusResource == null)
            {
                throw new ArgumentNullException(nameof(maritalStatusResource));
            }

            MaritalStatus maritalStatus = _mapper.Map<MaritalStatusResource, MaritalStatus>(maritalStatusResource);

            var result = await _maritalStatusService.UpdateAsync(id, maritalStatus).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            maritalStatusResource = _mapper.Map<MaritalStatus, MaritalStatusResource>(result.Resource);
            return Ok(maritalStatusResource);
        }

        /// <summary>
        /// Saves a new maritalStatus.
        /// </summary>
        /// <param name="resource">MaritalStatus data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/MaritalStatuses
        [HttpPost]
        [ProducesResponseType(typeof(MaritalStatusResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] MaritalStatusResource maritalStatusResource)
        {
            if (maritalStatusResource == null)
            {
                throw new ArgumentNullException(nameof(maritalStatusResource));
            }

            MaritalStatus maritalStatus = _mapper.Map<MaritalStatusResource, MaritalStatus>(maritalStatusResource);

            var result = await _maritalStatusService.AddAsync(maritalStatus).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            maritalStatusResource = _mapper.Map<MaritalStatus, MaritalStatusResource>(result.Resource);
            return Ok(maritalStatusResource);
        }

        /// <summary>
        /// Deletes a given maritalStatus according to an identifier.
        /// </summary>
        /// <param name="id">MaritalStatus identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/MaritalStatuses/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(MaritalStatusResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _maritalStatusService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var maritalStatusResource = _mapper.Map<MaritalStatus, MaritalStatusResource>(result.Resource);
            return Ok(maritalStatusResource);
        }
    }
}