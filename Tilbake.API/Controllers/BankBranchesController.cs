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
    public class BankBranchesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankBranchesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lists all banks branche.
        /// </summary>
        /// <returns>List of bank branchess.</returns>
        /// 
        // GET: api/BankBranches
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BankBranch>), 200)]
        public async Task<IEnumerable<BankBranch>> GetAllAsync()
        {
            return await _mediator.Send(new GetBankBranchesQuery()).ConfigureAwait(true);
        }

        /// <summary>
        /// Lists existing bank branches according to an identifier..
        /// </summary>
        /// <param name="bankId">BankBranch identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/BankBranches/Bank/5
        [HttpGet("Bank/{bankId}")]
        [ProducesResponseType(typeof(IEnumerable<BankBranch>), 200)]
        public async Task<IEnumerable<BankBranch>> GetBankAsync(Guid bankId)
        {
            return await _mediator.Send(new GetBankBranchesByBankIdQuery { BankId = bankId }).ConfigureAwait(true);
        }

        /// <summary>
        /// Lists an existing bank branch according to an identifier..
        /// </summary>
        /// <param name="id">BankBranch identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/BankBranches/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BankBranchResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankBranchResponse>> GetAsync(Guid id)
        {
            return await _mediator.Send(new GetBankBranchByIdQuery { Id = id }).ConfigureAwait(true);
        }

        /// <summary>
        /// Updates an existing bank branch according to an identifier.
        /// </summary>
        /// <param name="id">BankBranch identifier.</param>
        /// <param name="resource">Updated bank branch data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/BankBranches/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BankBranchResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankBranchResponse>> PutAsync(Guid id, [FromBody] UpdateBankBranchCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            command.Id = id;
            return await _mediator.Send(command).ConfigureAwait(true);

        }

        /// <summary>
        /// Saves a new bank branch.
        /// </summary>
        /// <param name="resource">BankBranch data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/BankBranches
        [HttpPost]
        [ProducesResponseType(typeof(BankBranchResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankBranchResponse>> PostAsync([FromBody] CreateBankBranchCommand command)
        {
            return await _mediator.Send(command).ConfigureAwait(true);
        }

        /// <summary>
        /// Deletes a given bank branch according to an identifier.
        /// </summary>
        /// <param name="id">BankBranch identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/BankBranches/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BankBranchResponse), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankBranchResponse>> DeleteAsync(Guid id)
        {
            return await _mediator.Send( new DeleteBankBranchCommand { Id = id }).ConfigureAwait(true);
        }
    }
}