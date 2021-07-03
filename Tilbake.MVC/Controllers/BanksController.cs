using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Domain.Models;
using Tilbake.MVC.Resources;

namespace Tilbake.MVC.Controllers
{
    public class BanksController : Controller
    {
        private readonly IBankService _bankService;
        private readonly IMapper _mapper;

        public BanksController(IBankService bankService, IMapper mapper)
        {
            _bankService = bankService ?? throw new ArgumentNullException(nameof(bankService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // GET: BanksController
        public async Task<IActionResult> Index()
        {
            var result = await _bankService.GetAllAsync().ConfigureAwait(true);
            var resources = _mapper.Map<IEnumerable<Bank>, IEnumerable<BankResource>>(result);

            ViewBag.datasource = resources;
            return View(resources);

        }

        // GET: BanksController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var result = await _bankService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
            return View(bankResource);
        }

        // GET: BanksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BanksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BankSaveResource bankSaveResource)
        {
            if (bankSaveResource == null)
            {
                throw new ArgumentNullException(nameof(bankSaveResource));
            }

            if (ModelState.IsValid)
            {
                Bank bank = _mapper.Map<BankSaveResource, Bank>(bankSaveResource);
                bank.Id = Guid.NewGuid();

                var result = await _bankService.AddAsync(bank).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bankSaveResource);
        }

        // GET: BanksController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var result = await _bankService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
            return View(bankResource);
        }

        // POST: BanksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, BankResource bankResource)
        {
            if (bankResource == null)
            {
                throw new ArgumentNullException(nameof(bankResource));
            }

            if (ModelState.IsValid)
            {
                Bank bank = _mapper.Map<BankResource, Bank>(bankResource);

                var result = await _bankService.UpdateAsync(id, bank).ConfigureAwait(true);
                if (!result.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bankResource);
        }

        // GET: BanksController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _bankService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
            return View(bankResource);
        }

        // POST: BanksController/Delete/5
        [HttpPost]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var result = await _bankService.GetByIdAsync(id).ConfigureAwait(true);
            if (!result.Success)
            {
                return BadRequest(new ErrorResource(result.Message));
            }

            try
            {
                var deleteResult = await _bankService.DeleteAsync(id).ConfigureAwait(true);
                if (!deleteResult.Success)
                {
                    return BadRequest(new ErrorResource(result.Message));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var bankResource = _mapper.Map<Bank, BankResource>(result.Resource);
                return View(bankResource);
            }
        }
    }
}
