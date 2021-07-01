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
    public class TitlesController : ControllerBase
    {
        private readonly ITitleService _titleService;
        private readonly IMapper _mapper;

        public TitlesController(ITitleService titleService, IMapper mapper)
        {
            _titleService = titleService ?? throw new ArgumentNullException(nameof(titleService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all titles.
        /// </summary>
        /// <returns>List of titles.</returns>
        /// 
        // GET: api/Titles
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TitleResource>), 200)]
        public async Task<IEnumerable<TitleResource>> GetAllAsync()
        {
            var result = await _titleService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Title>, IEnumerable<TitleResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing title according to an identifier..
        /// </summary>
        /// <param name="id">Title identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Titles/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TitleResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _titleService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var titleResource = _mapper.Map<Title, TitleResource>(result.Resource);
            return Ok(titleResource);
        }

        /// <summary>
        /// Updates an existing title according to an identifier.
        /// </summary>
        /// <param name="id">Title identifier.</param>
        /// <param name="resource">Updated title data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Titles/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(TitleResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] TitleResource titleResource)
        {
            if (titleResource == null)
            {
                throw new ArgumentNullException(nameof(titleResource));
            }

            Title title = _mapper.Map<TitleResource, Title>(titleResource);

            var result = await _titleService.UpdateAsync(id, title).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            titleResource = _mapper.Map<Title, TitleResource>(result.Resource);
            return Ok(titleResource);
        }

        /// <summary>
        /// Saves a new title.
        /// </summary>
        /// <param name="resource">Title data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Titles
        [HttpPost]
        [ProducesResponseType(typeof(TitleResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] TitleResource titleResource)
        {
            if (titleResource == null)
            {
                throw new ArgumentNullException(nameof(titleResource));
            }

            Title title = _mapper.Map<TitleResource, Title>(titleResource);

            var result = await _titleService.AddAsync(title).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            titleResource = _mapper.Map<Title, TitleResource>(result.Resource);
            return Ok(titleResource);
        }

        /// <summary>
        /// Deletes a given title according to an identifier.
        /// </summary>
        /// <param name="id">Title identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TitleResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _titleService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var titleResource = _mapper.Map<Title, TitleResource>(result.Resource);
            return Ok(titleResource);
        }
    }
}