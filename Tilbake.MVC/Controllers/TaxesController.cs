﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class TaxesController : BaseController
    {
        public TaxesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Taxes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Taxes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Tax>, IEnumerable<TaxViewModel>>(result);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetTaxRate(Guid id)
        {
            var result = await _unitOfWork.Taxes.GetById(id);
            var model = _mapper.Map<Tax, TaxViewModel>(result);
            return Json(new { model.Id, model.Name });
        }

        // GET: Taxes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Taxes.GetById(id);
            var model = _mapper.Map<Tax, TaxViewModel>(result);
            return View(model);
        }

        // GET: Taxes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Taxes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TaxViewModel model)
        {
            if (ModelState.IsValid)
            {
                var tax = _mapper.Map<TaxViewModel, Tax>(model);
                tax.Id = Guid.NewGuid();
                tax.DateAdded = DateTime.Now;

                await _unitOfWork.Taxes.Add(tax);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Taxes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Taxes.GetById(id);
            var model = _mapper.Map<Tax, TaxViewModel>(result);
            return View(model);
        }

        // POST: Taxes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, TaxViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var tax = _mapper.Map<TaxViewModel, Tax>(model);
                tax.DateModified = DateTime.Now;

                await _unitOfWork.Taxes.Update(tax);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Taxes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Taxes.GetById(id);
            var model = _mapper.Map<Tax, TaxViewModel>(result);
            return View(model);
        }

        // POST: Taxes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Taxes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
