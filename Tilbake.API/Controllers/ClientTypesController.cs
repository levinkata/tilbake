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
    public class ClientTypesController : ControllerBase
    {
        private readonly IClientTypeService _clientTypeService;
        private readonly IMapper _mapper;

        public ClientTypesController(IClientTypeService clientTypeService, IMapper mapper)
        {
            _clientTypeService = clientTypeService ?? throw new ArgumentNullException(nameof(clientTypeService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all clientTypes.
        /// </summary>
        /// <returns>List of clientTypes.</returns>
        /// 
        // GET: api/ClientTypes
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientTypeResource>), 200)]
        public async Task<IEnumerable<ClientTypeResource>> GetAllAsync()
        {
            var result = await _clientTypeService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<ClientType>, IEnumerable<ClientTypeResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing clientType according to an identifier..
        /// </summary>
        /// <param name="id">ClientType identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/ClientTypes/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientTypeResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _clientTypeService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientTypeResource = _mapper.Map<ClientType, ClientTypeResource>(result.Resource);
            return Ok(clientTypeResource);
        }

        /// <summary>
        /// Updates an existing clientType according to an identifier.
        /// </summary>
        /// <param name="id">ClientType identifier.</param>
        /// <param name="resource">Updated clientType data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/ClientTypes/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClientTypeResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] ClientTypeResource clientTypeResource)
        {
            if (clientTypeResource == null)
            {
                throw new ArgumentNullException(nameof(clientTypeResource));
            }

            ClientType clientType = _mapper.Map<ClientTypeResource, ClientType>(clientTypeResource);

            var result = await _clientTypeService.UpdateAsync(id, clientType).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            clientTypeResource = _mapper.Map<ClientType, ClientTypeResource>(result.Resource);
            return Ok(clientTypeResource);
        }

        /// <summary>
        /// Saves a new clientType.
        /// </summary>
        /// <param name="resource">ClientType data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/ClientTypes
        [HttpPost]
        [ProducesResponseType(typeof(ClientTypeResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] ClientTypeResource clientTypeResource)
        {
            if (clientTypeResource == null)
            {
                throw new ArgumentNullException(nameof(clientTypeResource));
            }

            ClientType clientType = _mapper.Map<ClientTypeResource, ClientType>(clientTypeResource);

            var result = await _clientTypeService.AddAsync(clientType).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            clientTypeResource = _mapper.Map<ClientType, ClientTypeResource>(result.Resource);
            return Ok(clientTypeResource);
        }

        /// <summary>
        /// Deletes a given clientType according to an identifier.
        /// </summary>
        /// <param name="id">ClientType identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/ClientTypes/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClientTypeResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _clientTypeService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientTypeResource = _mapper.Map<ClientType, ClientTypeResource>(result.Resource);
            return Ok(clientTypeResource);
        }
    }
}