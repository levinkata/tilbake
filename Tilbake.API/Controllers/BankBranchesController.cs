using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public BankBranchesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Lists all banks branche.
        /// </summary>
        /// <returns>List of bank branches.</returns>
        /// 
        // GET: api/BankBranches
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BankBranchResource>), 200)]
        public async Task<IEnumerable<BankBranchResource>> GetAllAsync()
        {
            var result = await _mediator.Send(new GetBankBranchesQuery()).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists existing bank branches according to a identifier..
        /// </summary>
        /// <param name="bankId">BankBranch identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/BankBranches/Bank/5
        [HttpGet("Bank/{bankId}")]
        [ProducesResponseType(typeof(IEnumerable<BankBranchResource>), 200)]
        public async Task<IEnumerable<BankBranchResource>> GetBankAsync(Guid bankId)
        {
            var result = await _mediator.Send(new GetBankBranchesByBankIdQuery { BankId = bankId }).ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);
            return resources;
        }

        /// <summary>
        /// Lists an existing bank branch according to an identifier..
        /// </summary>
        /// <param name="id">BankBranch identifier.</param>        
        /// <returns>Response for the request.</returns>
        /// 
        // GET: api/BankBranches/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BankBranchResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> GetAsync(Guid id)
        {
            var result = await _mediator.Send(new GetBankBranchByIdQuery { Id = id }).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
            return Ok(bankBranchResource);
        }

        /// <summary>
        /// Updates an existing bank branch according to an identifier.
        /// </summary>
        /// <param name="id">BankBranch identifier.</param>
        /// <param name="resource">Updated bank branch data.</param>
        /// <returns>Response for the request.</returns>
        // PUT: api/BankBranches/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(BankBranchResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] UpdateBankBranchCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            
            command.Id = id;
            var result = await _mediator.Send(command).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
            return Ok(bankBranchResource);

        }

        /// <summary>
        /// Saves a new bank branch.
        /// </summary>
        /// <param name="resource">BankBranch data.</param>
        /// <returns>Response for the request.</returns>
        // POST: api/BankBranches
        [HttpPost]
        [ProducesResponseType(typeof(BankBranchResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] CreateBankBranchCommand command)
        {
            var result = await _mediator.Send(command).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
            return Ok(bankBranchResource);
        }

        /// <summary>
        /// Deletes a given bank branch according to an identifier.
        /// </summary>
        /// <param name="id">BankBranch identifier.</param>
        /// <returns>Response for the request.</returns>
        // DELETE: api/BankBranches/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(BankBranchResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ActionResult<BankBranchResponse>> DeleteAsync(Guid id)
        {
            var result = await _mediator.Send( new DeleteBankBranchCommand { Id = id }).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
            return Ok(bankBranchResource);
        }
    }
}