using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]    
    public class CarriersController : ControllerBase
    {
        private readonly ICarrierService _carrierService;
        private readonly IMapper _mapper;

        public CarriersController(ICarrierService carrierService, IMapper mapper)
        {
            _carrierService = carrierService ?? throw new ArgumentNullException(nameof(carrierService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all carriers.
        /// </summary>
        /// <returns>List of carriers.</returns>
        /// 
        // GET: api/Carriers
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CarrierResource>), 200)]
        public async Task<IEnumerable<CarrierResource>> GetAllAsync()
        {
            var result = await _carrierService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing carrier according to an identifier..
        /// </summary>
        /// <param name="id">Carrier identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Carriers/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CarrierResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _carrierService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var carrierResource = _mapper.Map<Carrier, CarrierResource>(result.Resource);
            return Ok(carrierResource);
        }

        /// <summary>
        /// Updates an existing carrier according to an identifier.
        /// </summary>
        /// <param name="id">Carrier identifier.</param>
        /// <param name="resource">Updated carrier data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Carriers/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CarrierResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] CarrierSaveResource carrierSaveResource)
        {
            if (carrierSaveResource == null)
            {
                throw new ArgumentNullException(nameof(carrierSaveResource));
            }

            Carrier carrier = _mapper.Map<CarrierSaveResource, Carrier>(carrierSaveResource);

            var result = await _carrierService.UpdateAsync(id, carrier).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var carrierResource = _mapper.Map<Carrier, CarrierResource>(result.Resource);
            return Ok(carrierResource);
        }

        /// <summary>
        /// Saves a new carrier.
        /// </summary>
        /// <param name="resource">Carrier data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Carriers
        [HttpPost]
        [ProducesResponseType(typeof(CarrierResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] CarrierSaveResource carrierSaveResource)
        {
            if (carrierSaveResource == null)
            {
                throw new ArgumentNullException(nameof(carrierSaveResource));
            }

            Carrier carrier = _mapper.Map<CarrierSaveResource, Carrier>(carrierSaveResource);

            var result = await _carrierService.AddAsync(carrier).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var carrierResource = _mapper.Map<Carrier, CarrierResource>(result.Resource);
            return Ok(carrierResource);
        }

        /// <summary>
        /// Deletes a given carrier according to an identifier.
        /// </summary>
        /// <param name="id">Carrier identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Carriers/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CarrierResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _carrierService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var carrierResource = _mapper.Map<Carrier, CarrierResource>(result.Resource);
            return Ok(carrierResource);
        }
    }
}