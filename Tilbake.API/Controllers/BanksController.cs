using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tilbake.API.Resources;
using Tilbake.Application.Commands;
using Tilbake.Application.Communication;
using Tilbake.Application.Queries;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]    
    public class BanksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BanksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lists all banks.
        /// </summary>
        /// <returns>List of banks.</returns>
        /// 
        // GET: api/Banks
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Bank>), 200)]
        public async Task<IEnumerable<Bank>> GetAllAsync()
        {
            return await _mediator.Send(new GetBanksQuery()).ConfigureAwait(true);
        }

        /// <summary>
        /// Lists an existing bank according to an identifier..
        /// </summary>
        /// <param name="id">Bank identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/Banks/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BankResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankResponse>> GetAsync(Guid id)
        {
            return await _mediator.Send(new GetBankByIdQuery { Id = id }).ConfigureAwait(true);
        }

        /// <summary>
        /// Updates an existing bank according to an identifier.
        /// </summary>
        /// <param name="id">Bank identifier.</param>
        /// <param name="resource">Updated bank data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/Banks/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BankResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankResponse>> PutAsync(Guid id, [FromBody] UpdateBankCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            command.Id = id;
            return await _mediator.Send(command).ConfigureAwait(true);

        }

        /// <summary>
        /// Saves a new bank.
        /// </summary>
        /// <param name="resource">Bank data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/Banks
        [HttpPost]
        [ProducesResponseType(typeof(BankResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankResponse>> PostAsync([FromBody] CreateBankCommand command)
        {
            return await _mediator.Send(command).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes a given bank according to an identifier.
        /// </summary>
        /// <param name="id">Bank identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BankResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankResponse>> DeleteAsync(Guid id)
        {
            return await _mediator.Send( new DeleteBankCommand { Id = id }).ConfigureAwait(true);
        }
    }
}