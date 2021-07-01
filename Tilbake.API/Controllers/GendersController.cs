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
    public class GendersController : ControllerBase
    {
        private readonly IGenderService _genderService;
        private readonly IMapper _mapper;

        public GendersController(IGenderService genderService, IMapper mapper)
        {
            _genderService = genderService ?? throw new ArgumentNullException(nameof(genderService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all genders.
        /// </summary>
        /// <returns>List of genders.</returns>
        /// 
        // GET: api/Genders
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GenderResource>), 200)]
        public async Task<IEnumerable<GenderResource>> GetAllAsync()
        {
            var result = await _genderService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Gender>, IEnumerable<GenderResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing gender according to an identifier..
        /// </summary>
        /// <param name="id">Gender identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Genders/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GenderResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _genderService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var genderResource = _mapper.Map<Gender, GenderResource>(result.Resource);
            return Ok(genderResource);
        }

        /// <summary>
        /// Updates an existing gender according to an identifier.
        /// </summary>
        /// <param name="id">Gender identifier.</param>
        /// <param name="resource">Updated gender data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Genders/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(GenderResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] GenderSaveResource genderSaveResource)
        {
            if (genderSaveResource == null)
            {
                throw new ArgumentNullException(nameof(genderSaveResource));
            }

            Gender gender = _mapper.Map<GenderSaveResource, Gender>(genderSaveResource);

            var result = await _genderService.UpdateAsync(id, gender).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var genderResource = _mapper.Map<Gender, GenderResource>(result.Resource);
            return Ok(genderResource);
        }

        /// <summary>
        /// Saves a new gender.
        /// </summary>
        /// <param name="resource">Gender data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Genders
        [HttpPost]
        [ProducesResponseType(typeof(GenderResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] GenderSaveResource genderSaveResource)
        {
            if (genderSaveResource == null)
            {
                throw new ArgumentNullException(nameof(genderSaveResource));
            }

            Gender gender = _mapper.Map<GenderSaveResource, Gender>(genderSaveResource);

            var result = await _genderService.AddAsync(gender).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var genderResource = _mapper.Map<Gender, GenderResource>(result.Resource);
            return Ok(genderResource);
        }

        /// <summary>
        /// Deletes a given gender according to an identifier.
        /// </summary>
        /// <param name="id">Gender identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Genders/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(GenderResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _genderService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var genderResource = _mapper.Map<Gender, GenderResource>(result.Resource);
            return Ok(genderResource);
        }
    }
}