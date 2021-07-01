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
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;

        public ClientsController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService ?? throw new ArgumentNullException(nameof(clientService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all clients.
        /// </summary>
        /// <returns>List of clients.</returns>
        /// 
        // GET: api/Clients
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ClientResource>), 200)]
        public async Task<IEnumerable<ClientResource>> GetAllAsync()
        {
            var result = await _clientService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing client according to an identifier..
        /// </summary>
        /// <param name="id">Client identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Clients/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ClientResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _clientService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }

        /// <summary>
        /// Updates an existing client according to an identifier.
        /// </summary>
        /// <param name="id">Client identifier.</param>
        /// <param name="resource">Updated client data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Clients/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ClientResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] ClientSaveResource clientSaveResource)
        {
            if (clientSaveResource == null)
            {
                throw new ArgumentNullException(nameof(clientSaveResource));
            }

            Client client = _mapper.Map<ClientSaveResource, Client>(clientSaveResource);

            var result = await _clientService.UpdateAsync(id, client).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }

        /// <summary>
        /// Saves a new client.
        /// </summary>
        /// <param name="resource">Client data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Clients
        [HttpPost]
        [ProducesResponseType(typeof(ClientResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] ClientSaveResource clientSaveResource)
        {
            if (clientSaveResource == null)
            {
                throw new ArgumentNullException(nameof(clientSaveResource));
            }

            Client client = _mapper.Map<ClientSaveResource, Client>(clientSaveResource);

            var result = await _clientService.AddAsync(client).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }

        /// <summary>
        /// Deletes a given client according to an identifier.
        /// </summary>
        /// <param name="id">Client identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ClientResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _clientService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var clientResource = _mapper.Map<Client, ClientResource>(result.Resource);
            return Ok(clientResource);
        }
    }
}