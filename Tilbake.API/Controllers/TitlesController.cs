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
    public class TitlesController : ControllerBase
    {
        private readonly ITitleService _titleService;
        private readonly IMapper _mapper;

        public TitlesController(ITitleService titleService, IMapper mapper)
        {
            _titleService = titleService;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all titles.
        /// </summary>
        /// <returns>List of titles.</returns>
        /// 
        // GET: api/Titles
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<TitleResource>), 200)]
        public async Task<IEnumerable<TitleResource>> GetAsync()
        {
            var titles = await _titleService.GetAllAsync().ConfigureAwait(true);

            var resources = _mapper.Map<IEnumerable<Title>, IEnumerable<TitleResource>>(titles);
            return resources;
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(TitleResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _titleService.GetAsync(id).ConfigureAwait(true);
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
        [ProducesResponseType(typeof(TitleResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveTitleResource resource)
        {
            var title = _mapper.Map<SaveTitleResource, Title>(resource);
            var result = await _titleService.UpdateAsync(id, title).ConfigureAwait(true);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var titleResource = _mapper.Map<Title, TitleResource>(result.Resource);
            return Ok(titleResource);
        }

        /// <summary>
        /// Saves a new title.
        /// </summary>
        /// <param name="resource">Title data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Titles
        [HttpPost]
        [ProducesResponseType(typeof(TitleResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> PostAsync([FromBody] SaveTitleResource resource)
        {
            var title = _mapper.Map<SaveTitleResource, Title>(resource);
            var result = await _titleService.SaveAsync(title).ConfigureAwait(true);

            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var titleResource = _mapper.Map<Title, TitleResource>(result.Resource);
            return Ok(titleResource);
        }

        /// <summary>
        /// Deletes a given title according to an identifier.
        /// </summary>
        /// <param name="id">Title identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(TitleResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<IActionResult> DeleteAsync(Guid id)
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
