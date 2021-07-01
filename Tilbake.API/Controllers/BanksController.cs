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
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;

        public BanksController(IBankService bankService, IMapper mapper)
        {
            _bankService = bankService ?? throw new ArgumentNullException(nameof(bankService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Lists all banks.
        /// </summary>
        /// <returns>List of banks.</returns>
        /// 
        // GET: api/Banks
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BankResource>), 200)]
        public async Task<IEnumerable<BankResource>> GetAllAsync()
        {
            var result = await _bankService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Bank>, IEnumerable<BankResource>>(result);
            return resources;
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
        public async Task<ActionResult<IActionResult>> GetByIdAsync(Guid id)
        {
            var result = await _bankService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
            return Ok(bankResource);
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
        public async Task<ActionResult<IActionResult>> PutAsync(Guid id, [FromBody] BankSaveResource bankSaveResource)
        {
            if (bankSaveResource == null)
            {
                throw new ArgumentNullException(nameof(bankSaveResource));
            }

            Bank bank = _mapper.Map<BankSaveResource, Bank>(bankSaveResource);

            var result = await _bankService.UpdateAsync(id, bank).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
            return Ok(bankResource);
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
        public async Task<ActionResult<IActionResult>> PostAsync([FromBody] BankSaveResource bankSaveResource)
        {
            if (bankSaveResource == null)
            {
                throw new ArgumentNullException(nameof(bankSaveResource));
            }

            Bank bank = _mapper.Map<BankSaveResource, Bank>(bankSaveResource);

            var result = await _bankService.AddAsync(bank).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
            return Ok(bankResource);
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
        public async Task<ActionResult<IActionResult>> DeleteAsync(Guid id)
        {
            var result = await _bankService.DeleteAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
            return Ok(bankResource);
        }
    }
}