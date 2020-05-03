using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Interfaces;
using Tilbake.Application.ViewModels;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Data.Context;

namespace Tilbake.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BanksController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BanksController(IBankService bankService)
        {
            _bankService = bankService;
        }

        // GET: api/Banks
        [HttpGet]
        public async Task<IActionResult> GetBanks()
        {
            BanksViewModel model = await _bankService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.Banks)).ConfigureAwait(true);
        }

        // GET: api/Banks/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBank(Guid id)
        {
            BankViewModel model = await _bankService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.Bank)).ConfigureAwait(true);
        }

        // PUT: api/Banks/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBank(Guid id, Bank bank)
        {
            if (bank == null)
            {
                throw new ArgumentNullException(nameof(bank));
            }

            if (id != bank.ID)
            {
                return BadRequest();
            }

            BankViewModel model = new BankViewModel()
            {
                Bank = bank
            };

            await _bankService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/Banks
        [HttpPost]
        public async Task<IActionResult> PostBank(Bank bank)
        {
            BankViewModel model = new BankViewModel()
            {
                Bank = bank
            };

            await _bankService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/Banks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBank(Guid id)
        {
            BankViewModel model = await _bankService.GetAsync(id).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _bankService.DeleteAsync(id).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
