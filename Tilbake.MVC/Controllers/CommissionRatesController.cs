using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class CommissionRatesController : Controller
    {
        private readonly ICommissionRateService _commissionRateService;

        public CommissionRatesController(ICommissionRateService commissionRateService)
        {
            _commissionRateService = commissionRateService;
        }

        public async Task<IActionResult> Index()
        {
            var ViewModels = await _commissionRateService.GetAllAsync();
            return View(ViewModels);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CommissionRateViewModel ViewModel = new()
            {
                RiskList = SelectLists.RegisteredRisks(null)
            };
            return await Task.Run(() => View(ViewModel));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommissionRateViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _commissionRateService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }

            ViewModel.RiskList = SelectLists.RegisteredRisks(ViewModel.RiskName);
            return View(ViewModel);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var ViewModel = await _commissionRateService.GetByIdAsync(id);
            return View(ViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var ViewModel = await _commissionRateService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            ViewModel.RiskList = SelectLists.RegisteredRisks(ViewModel.RiskName);
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, CommissionRateViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _commissionRateService.UpdateAsync(ViewModel);
                    return RedirectToAction(nameof(Details), new { id = ViewModel.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            ViewModel.RiskList = SelectLists.RegisteredRisks(ViewModel.RiskName);
            return View(ViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _commissionRateService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(CommissionRateViewModel ViewModel)
        {
            _commissionRateService.DeleteAsync(ViewModel.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
