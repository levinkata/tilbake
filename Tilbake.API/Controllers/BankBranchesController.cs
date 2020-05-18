using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankBranchesController : ControllerBase
    {
        private readonly IBankBranchService _bankBranchService;

        public BankBranchesController(IBankBranchService bankBranchService)
        {
            _bankBranchService = bankBranchService;
        }

        // GET: api/BankBranches
        [HttpGet]
        public async Task<IActionResult> GetBankBranches()
        {
            BankBranchesViewModel model = await _bankBranchService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.BankBranches)).ConfigureAwait(true);
        }

        // GET: api/BankBranches/Bank/5
        [HttpGet("Bank/{bankId}")]
        public async Task<ActionResult> GetByBank(Guid bankId)
        {
            BankBranchesViewModel model = await _bankBranchService.GetByBankAsync(bankId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.BankBranches)).ConfigureAwait(true);
        }

        // GET: api/BankBranches/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankBranch(Guid id)
        {
            BankBranchViewModel model = await _bankBranchService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.BankBranch)).ConfigureAwait(true);
        }

        // PUT: api/BankBranches/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBankBranch(Guid id, BankBranch bankBranch)
        {
            if (bankBranch == null)
            {
                throw new ArgumentNullException(nameof(bankBranch));
            }

            if (id != bankBranch.ID)
            {
                return BadRequest();
            }

            BankBranchViewModel model = new BankBranchViewModel()
            {
                BankBranch = bankBranch
            };

            await _bankBranchService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/BankBranches
        [HttpPost]
        public async Task<IActionResult> PostBankBranch(BankBranch bankBranch)
        {
            BankBranchViewModel model = new BankBranchViewModel()
            {
                BankBranch = bankBranch
            };

            await _bankBranchService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/BankBranches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBankBranch(Guid id)
        {
            BankBranchViewModel model = await _bankBranchService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _bankBranchService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
