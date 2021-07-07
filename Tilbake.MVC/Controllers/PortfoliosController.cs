using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tilbake.Application.Communication;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;
using Tilbake.Domain.Models;
using Tilbake.Infrastructure.Persistence.Context;

namespace Tilbake.MVC.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly IPortfolioService _portfolioService;

        public PortfoliosController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
            var resources = await _portfolioService.GetAllAsync().ConfigureAwait(true);
            ViewBag.datasource = resources;

            return View(resources);
        }

        // GET: Portfolios/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var resource = await _portfolioService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Portfolios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Portfolios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioSaveResource portfolioSaveResource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioService.AddAsync(portfolioSaveResource).ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioSaveResource);
        }

        // GET: Portfolios/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var resource = await _portfolioService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Portfolios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PortfolioResource portfolioResource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioService.UpdateAsync(portfolioResource).ConfigureAwait(true);
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioResource);
        }

        // GET: Portfolios/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var resource = await _portfolioService.GetByIdAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Portfolios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _portfolioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
