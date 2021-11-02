using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resources = await _commissionRateService.GetAllAsync();
            return View(resources);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CommissionRateSaveResource resource = new()
            {
                RiskList = SelectLists.RegisteredRisks(null)
            };
            return await Task.Run(() => View(resource));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CommissionRateSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _commissionRateService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }

            resource.RiskList = SelectLists.RegisteredRisks(resource.RiskName);
            return View(resource);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var resource = await _commissionRateService.GetByIdAsync(id);
            return View(resource);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _commissionRateService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            resource.RiskList = SelectLists.RegisteredRisks(resource.RiskName);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, CommissionRateResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _commissionRateService.UpdateAsync(resource);
                    return RedirectToAction(nameof(Details), new { id = resource.Id });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            resource.RiskList = SelectLists.RegisteredRisks(resource.RiskName);
            return View(resource);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _commissionRateService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(CommissionRateResource resource)
        {
            _commissionRateService.DeleteAsync(resource.Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
