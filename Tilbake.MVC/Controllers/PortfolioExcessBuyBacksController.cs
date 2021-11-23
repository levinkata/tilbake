using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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

            var ViewModel = await _portfolioExcessBuyBackService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: PortfolioExcessBuyBacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PortfolioExcessBuyBacks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PortfolioExcessBuyBackViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _portfolioExcessBuyBackService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: PortfolioExcessBuyBacks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _portfolioExcessBuyBackService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: PortfolioExcessBuyBacks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, PortfolioExcessBuyBackViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _portfolioExcessBuyBackService.UpdateAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: PortfolioExcessBuyBacks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _portfolioExcessBuyBackService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: PortfolioExcessBuyBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _portfolioExcessBuyBackService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
