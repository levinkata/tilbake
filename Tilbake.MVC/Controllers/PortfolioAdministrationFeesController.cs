using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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

            PortfolioAdministrationFeeSaveResource resource = new()
            {
                InsurerList = SelectLists.Insurers(insurers, Guid.Empty),
                PortfolioId = portfolioId
            };
            return View(resource);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioAdministrationFeeSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _portfolioAdministrationFeeService.Add(resource);
                return RedirectToAction(nameof(Details), new { portfolioId = resource.PortfolioId });
            }

            var insurers = await _insurerService.GetAllAsync();
            resource.InsurerList = SelectLists.Insurers(insurers, resource.InsurerId);
            return View(resource);
        }

        public async Task<IActionResult> Details(Guid portfolioId)
        {
            var policyFees = await _portfolioAdministrationFeeService.GetByPortfolioIdAsync(portfolioId);
            
            if (!policyFees.Any())
            {
                return RedirectToAction(nameof(Create), new { portfolioId });
            }
            var resource = policyFees.FirstOrDefault();
            return View(resource);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _portfolioAdministrationFeeService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }
            var insurers = await _insurerService.GetAllAsync();
            resource.InsurerList = SelectLists.Insurers(insurers, resource.InsurerId);
            return View(resource);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PortfolioAdministrationFeeResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _portfolioAdministrationFeeService.Update(resource);
                    return RedirectToAction(nameof(Details), new { portfolioId = resource.PortfolioId });
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }

            var insurers = await _insurerService.GetAllAsync();
            resource.InsurerList = SelectLists.Insurers(insurers, resource.InsurerId);
            return View(resource);
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _portfolioAdministrationFeeService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(PortfolioAdministrationFeeResource resource)
        {
            _portfolioAdministrationFeeService.Delete(resource.Id);
            return RedirectToAction("Carousel", "Portfolios", new { portfolioId = resource.PortfolioId });
        }
    }
}
