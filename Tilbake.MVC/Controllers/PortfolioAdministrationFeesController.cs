using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    public class PortfolioAdministrationFeesController : Controller
    {
        private readonly IPortfolioAdministrationFeeService _portfolioAdministrationFeeService;
        private readonly IInsurerService _insurerService;

        public PortfolioAdministrationFeesController(
                        IPortfolioAdministrationFeeService portfolioAdministrationFeeService,
                        IInsurerService insurerService)
        {
            _portfolioAdministrationFeeService = portfolioAdministrationFeeService;
            _insurerService = insurerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create(Guid portfolioId)
        {
            var insurers = await _insurerService.GetAllAsync();

            PortfolioAdministrationFeeViewModel ViewModel = new()
            {
                InsurerList = SelectLists.Insurers(insurers, Guid.Empty),
                PortfolioId = portfolioId
            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioAdministrationFeeViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                await _portfolioAdministrationFeeService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Details), new { portfolioId = ViewModel.PortfolioId });
            }

            var insurers = await _insurerService.GetAllAsync();
            ViewModel.InsurerList = SelectLists.Insurers(insurers, ViewModel.InsurerId);
            return View(ViewModel);
        }

        public async Task<IActionResult> Details(Guid portfolioId)
        {
            var policyFees = await _portfolioAdministrationFeeService.GetByPortfolioIdAsync(portfolioId);
            
            if (!policyFees.Any())
            {
                return RedirectToAction(nameof(Create), new { portfolioId });
            }
            var ViewModel = policyFees.FirstOrDefault();
            return View(ViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var ViewModel = await _portfolioAdministrationFeeService.GetByIdAsync(id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            var insurers = await _insurerService.GetAllAsync();
            ViewModel.InsurerList = SelectLists.Insurers(insurers, ViewModel.InsurerId);
            return View(ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PortfolioAdministrationFeeViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _portfolioAdministrationFeeService.UpdateAsync(ViewModel);
                    return RedirectToAction(nameof(Details), new { portfolioId = ViewModel.PortfolioId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            var insurers = await _insurerService.GetAllAsync();
            ViewModel.InsurerList = SelectLists.Insurers(insurers, ViewModel.InsurerId);
            return View(ViewModel);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _portfolioAdministrationFeeService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(PortfolioAdministrationFeeViewModel ViewModel)
        {
            _portfolioAdministrationFeeService.DeleteAsync(ViewModel.Id);
            return RedirectToAction("Carousel", "Portfolios", new { portfolioId = ViewModel.PortfolioId });
        }
    }
}
