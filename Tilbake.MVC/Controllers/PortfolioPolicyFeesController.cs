using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Helpers;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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

            PortfolioPolicyFeeSaveResource resource = new()
            {
                InsurerList = SelectLists.Insurers(insurers, Guid.Empty),
                PortfolioId = portfolioId
            };
            return View(resource);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioPolicyFeeSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioPolicyFeeService.AddAsync(resource);
                return RedirectToAction(nameof(Details), new { portfolioId = resource.PortfolioId });
            }

            var insurers = await _insurerService.GetAllAsync();
            resource.InsurerList = SelectLists.Insurers(insurers, resource.InsurerId);
            return View(resource);
        }

        public async Task<IActionResult> Details(Guid portfolioId)
        {
            var policyFees = await _portfolioPolicyFeeService.GetByPortfolioIdAsync(portfolioId);
            
            if (!policyFees.Any())
            {
                return RedirectToAction(nameof(Create), new { portfolioId });
            }
            var resource = policyFees.FirstOrDefault();
            return View(resource);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _portfolioPolicyFeeService.GetByIdAsync(id);
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
        public async Task<IActionResult> Edit(Guid? id, PortfolioPolicyFeeResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _portfolioPolicyFeeService.UpdateAsync(resource);
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

            var resource = await _portfolioPolicyFeeService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(PortfolioPolicyFeeResource resource)
        {
            await _portfolioPolicyFeeService.DeleteAsync(resource.Id);
            return RedirectToAction("Carousel", "Portfolios", new { portfolioId = resource.PortfolioId });
        }
    }
}
