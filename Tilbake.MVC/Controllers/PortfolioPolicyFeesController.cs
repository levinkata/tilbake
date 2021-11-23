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
    public class PortfolioPolicyFeesController : Controller
    {
        private readonly IPortfolioPolicyFeeService _portfolioPolicyFeeService;
        private readonly IInsurerService _insurerService;

        public PortfolioPolicyFeesController(
                        IPortfolioPolicyFeeService portfolioPolicyFeeService,
                        IInsurerService insurerService)
        {
            _portfolioPolicyFeeService = portfolioPolicyFeeService;
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

            PortfolioPolicyFeeViewModel ViewModel = new()
            {
                InsurerList = SelectLists.Insurers(insurers, Guid.Empty),
                PortfolioId = portfolioId
            };
            return View(ViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioPolicyFeeViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                await _portfolioPolicyFeeService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Details), new { portfolioId = ViewModel.PortfolioId });
            }

            var insurers = await _insurerService.GetAllAsync();
            ViewModel.InsurerList = SelectLists.Insurers(insurers, ViewModel.InsurerId);
            return View(ViewModel);
        }

        public async Task<IActionResult> Details(Guid portfolioId)
        {
            var policyFees = await _portfolioPolicyFeeService.GetByPortfolioIdAsync(portfolioId);
            
            if (!policyFees.Any())
            {
                return RedirectToAction(nameof(Create), new { portfolioId });
            }
            var ViewModel = policyFees.FirstOrDefault();
            return View(ViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var ViewModel = await _portfolioPolicyFeeService.GetByIdAsync(id);
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
        public async Task<IActionResult> Edit(Guid? id, PortfolioPolicyFeeViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _portfolioPolicyFeeService.UpdateAsync(ViewModel);
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

            var ViewModel = await _portfolioPolicyFeeService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(PortfolioPolicyFeeViewModel ViewModel)
        {
            _portfolioPolicyFeeService.DeleteAsync(ViewModel.Id);
            return RedirectToAction("Carousel", "Portfolios", new { portfolioId = ViewModel.PortfolioId });
        }
    }
}
