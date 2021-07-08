using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;

namespace Tilbake.MVC.Controllers
{
    public class BankBranchesController : Controller
    {

        private readonly IBankBranchService _bankBranchService;
        private readonly IMapper _mapper;

        public BankBranchesController(IBankBranchService bankBranchService, IMapper mapper)
        {
            _bankBranchService = bankBranchService ?? throw new ArgumentNullException(nameof(bankBranchService));

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: BankBranches
        public async Task<IActionResult> Index()
        {
            var result = await _bankBranchService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<BankBranch>, IEnumerable<BankBranchResource>>(result);

            return View(resources);
        }

        // GET: BankBranches/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _bankBranchService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
            return View(bankBranchResource);
        }

        // GET: BankBranches/Create
        public IActionResult Create(Guid bankId)
        {
            BankBranchSaveResource bankBranchSaveResource = new BankBranchSaveResource()
            {
                BankId = bankId
            };
            return View(bankBranchSaveResource);
        }

        // POST: BankBranches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BankBranchSaveResource bankBranchSaveResource)
        {
            if (bankBranchSaveResource == null)
            {
                throw new ArgumentNullException(nameof(bankBranchSaveResource));
            }

            if (ModelState.IsValid)
            {
                BankBranch bankBranch = _mapper.Map<BankBranchSaveResource, BankBranch>(bankBranchSaveResource);
                bankBranch.Id = Guid.NewGuid();

                var result = await _bankBranchService.AddAsync(bankBranch).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bankBranchSaveResource);
        }

        // GET: BankBranches/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _bankBranchService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
            return View(bankBranchResource);
        }

        // POST: BankBranches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, BankBranchResource bankBranchResource)
        {
            if (id != bankBranchResource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                BankBranch bankBranch = _mapper.Map<BankBranchResource, BankBranch>(bankBranchResource);

                var result = await _bankBranchService.UpdateAsync(id, bankBranch).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bankBranchResource);
        }

        // GET: BankBranches/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _bankBranchService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
            return View(bankBranchResource);
        }

        // POST: BankBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _bankBranchService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            try
            {
                var deleteResult = await _bankBranchService.DeleteAsync(id).ConfigureAwait(true);
                if (!deleteResult.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var bankBranchResource = _mapper.Map<BankBranch, BankBranchResource>(result.Resource);
                return View(bankBranchResource);
            }
        }
    }
}
