using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class BankBranchesController : Controller
    {
        private readonly IBankBranchService _bankBranchService;
        private readonly IBankService _bankService;

        public BankBranchesController(IBankBranchService bankBranchService,
                                        IBankService bankService)
        {
            _bankBranchService = bankBranchService;
            _bankService = bankService;
        }

        // GET: BankBranches
        public async Task<IActionResult> Index(Guid bankId)
        {
            ViewBag.BankId = bankId;
            return View(await _bankBranchService.GetByBankIdAsync(bankId));
        }

        // GET: BankBranches/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _bankBranchService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: BankBranches/Create
        public async Task<IActionResult> Create(Guid bankId)
        {
            var bank = await _bankService.GetByIdAsync(bankId);

            BankBranchSaveResource resource = new()
            {
                BankId = bankId,
                Bank = bank.Name
            };
            return View(resource);
        }

        // POST: BankBranches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BankBranchSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _bankBranchService.AddAsync(resource);
                return RedirectToAction(nameof(Details), "Banks", new { id = resource.BankId });
            }
            return View(resource);
        }

        // GET: BankBranches/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _bankBranchService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, BankBranchResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _bankBranchService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Details), new { id = resource.Id });
            }
            return View(resource);
        }

        // GET: BankBranches/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _bankBranchService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: BankBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(BankBranchResource resource)
        {
            _bankBranchService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Details), "Banks", new { id = resource.BankId });
        }
    }
}
