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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IMapper _mapper;

        public CountriesController(ICountryService countryService, IMapper mapper)
        {
            _countryService = countryService ?? throw new ArgumentNullException(nameof(countryService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all countries.
        /// </summary>
        /// <returns>List of countries.</returns>
        /// 
        // GET: api/Countries
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CountryResource>), 200)]
        public async Task<IEnumerable<CountryResource>> GetAllAsync()
        {
            var result = await _countryService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Country>, IEnumerable<CountryResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing country according to an identifier..
        /// </summary>
        /// <param name="id">Country identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Countries/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CountryResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _countryService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
            return Ok(countryResource);
        }

        /// <summary>
        /// Updates an existing country according to an identifier.
        /// </summary>
        /// <param name="id">Country identifier.</param>
        /// <param name="resource">Updated country data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Countries/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CountryResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] CountrySaveResource countrySaveResource)
        {
            if (countrySaveResource == null)
            {
                throw new ArgumentNullException(nameof(countrySaveResource));
            }

            Country country = _mapper.Map<CountrySaveResource, Country>(countrySaveResource);

            var result = await _countryService.UpdateAsync(id, country).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
            return Ok(countryResource);
        }

        /// <summary>
        /// Saves a new country.
        /// </summary>
        /// <param name="resource">Country data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Countries
        [HttpPost]
        [ProducesResponseType(typeof(CountryResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] CountrySaveResource countrySaveResource)
        {
            if (countrySaveResource == null)
            {
                throw new ArgumentNullException(nameof(countrySaveResource));
            }

            Country country = _mapper.Map<CountrySaveResource, Country>(countrySaveResource);

            var result = await _countryService.AddAsync(country).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
            return Ok(countryResource);
        }

        /// <summary>
        /// Deletes a given country according to an identifier.
        /// </summary>
        /// <param name="id">Country identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CountryResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _countryService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var countryResource = _mapper.Map<Country, CountryResource>(result.Resource);
            return Ok(countryResource);
        }
    }
}