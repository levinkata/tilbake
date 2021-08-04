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

        public BankBranchesController(IBankBranchService bankBranchService)
        {
            _bankBranchService = bankBranchService;
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankBranches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankBranchSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _bankBranchService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
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

        // POST: BankBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, BankBranchResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bankBranchService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _bankBranchService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
