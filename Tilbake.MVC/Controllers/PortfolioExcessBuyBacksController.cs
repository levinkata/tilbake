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
    public class PortfolioExcessBuyBacksController : Controller
    {
        private readonly IPortfolioExcessBuyBackService _portfolioExcessBuyBackService;

        public PortfolioExcessBuyBacksController(IPortfolioExcessBuyBackService portfolioExcessBuyBackService)
        {
            _portfolioExcessBuyBackService = portfolioExcessBuyBackService;
        }

        // GET: PortfolioExcessBuyBacks
        public async Task<IActionResult> Index(Guid portfolioId)
        {
            return View(await _portfolioExcessBuyBackService.GetByPortfolioIdAsync(portfolioId));
        }

        // GET: PortfolioExcessBuyBacks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _portfolioExcessBuyBackService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: PortfolioExcessBuyBacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioExcessBuyBacks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioExcessBuyBackSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioExcessBuyBackService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: PortfolioExcessBuyBacks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _portfolioExcessBuyBackService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: PortfolioExcessBuyBacks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PortfolioExcessBuyBackResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _portfolioExcessBuyBackService.UpdateAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: PortfolioExcessBuyBacks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _portfolioExcessBuyBackService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: PortfolioExcessBuyBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _portfolioExcessBuyBackService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
