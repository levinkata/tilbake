﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class PortfoliosController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IFileTemplateService _fileTemplateService;

        public PortfoliosController(IPortfolioService portfolioService, IFileTemplateService fileTemplateService)
        {
            _portfolioService = portfolioService;
            _fileTemplateService = fileTemplateService;
        }

        // GET: Portfolios
        public async Task<IActionResult> Index()
        {
            var resources = await _portfolioService.GetAllAsync();
            ViewBag.datasource = resources;

            return View(resources);
        }

        public async Task<IActionResult> Carousel(Guid portfolioId)
        {
            var resource = await _portfolioService.GetByIdAsync(portfolioId);

            return View(resource);
        }

        public async Task<ActionResult> SelectFileTemplate(Guid portfolioId)
        {
            var portfolio = await _portfolioService.GetByIdAsync(portfolioId);
            var resources = await _fileTemplateService.GetByPortfolioIdAsync(portfolioId);

            ViewBag.PortfolioId = portfolioId;
            ViewBag.PortfolioName = portfolio.Name;
  
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PortfolioSaveResource portfolioSaveResource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioService.AddAsync(portfolioSaveResource);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PortfolioResource portfolioResource)
        {
            if (ModelState.IsValid)
            {
                await _portfolioService.UpdateAsync(portfolioResource);
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
