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
    public class KlientBankAccountsController : ControllerBase
    {
        private readonly IKlientBankAccountService _klientBankAccountService;

        public KlientBankAccountsController(IKlientBankAccountService klientBankAccountService)
        {
            _klientBankAccountService = klientBankAccountService ?? throw new ArgumentNullException(nameof(klientBankAccountService));
        }

        // GET: api/KlientBankAccounts
        [HttpGet]
        public async Task<ActionResult> GetKlientBankAccounts()
        {
            KlientBankAccountsViewModel model = await _klientBankAccountService.GetAllAsync().ConfigureAwait(true);
            return await Task.Run(() => Ok(model.KlientBankAccounts)).ConfigureAwait(true);
        }

        // GET: api/KlientBankAccounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetKlientBankAccount(Guid klientId, Guid bankAccountId)
        {
            KlientBankAccountViewModel model = await _klientBankAccountService.GetAsync(klientId, bankAccountId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            return await Task.Run(() => Ok(model.KlientBankAccount)).ConfigureAwait(true);
        }

        // PUT: api/KlientBankAccounts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKlientBankAccount(Guid klientId, KlientBankAccount klientBankAccount)
        {
            if (klientBankAccount == null)
            {
                throw new ArgumentNullException(nameof(klientBankAccount));
            }

            if (klientId != klientBankAccount.KlientID)
            {
                return BadRequest();
            }

            KlientBankAccountViewModel model = new KlientBankAccountViewModel()
            {
                KlientBankAccount = klientBankAccount
            };

            await _klientBankAccountService.UpdateAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // POST: api/KlientBankAccounts
        [HttpPost]
        public async Task<ActionResult> PostKlientBankAccount(KlientBankAccount klientBankAccount)
        {
            KlientBankAccountViewModel model = new KlientBankAccountViewModel()
            {
                KlientBankAccount = klientBankAccount
            };

            await _klientBankAccountService.AddAsync(model).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }

        // DELETE: api/KlientBankAccounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKlientBankAccount(Guid klientId, Guid bankAccountId)
        {
            KlientBankAccountViewModel model = await _klientBankAccountService.GetAsync(klientId, bankAccountId).ConfigureAwait(true);
            if (model == null)
            {
                return NotFound();
            }

            await _klientBankAccountService.DeleteAsync(klientId, bankAccountId).ConfigureAwait(true);
            return await Task.Run(() => NoContent()).ConfigureAwait(true);
        }
    }
}
