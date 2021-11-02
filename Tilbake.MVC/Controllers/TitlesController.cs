﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

namespace Tilbake.MVC.Controllers
{
    public class TitlesController : Controller
    {
        private readonly ITitleService _titleService;

        public TitlesController(ITitleService titleService)
        {
            _titleService = titleService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _titleService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetTitles()
        {
            var resources = await _titleService.GetAllAsync();
            var titles = from m in resources
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };

            return Json(titles);
        }        

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _titleService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TitleSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                _titleService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _titleService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: Titles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, TitleResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _titleService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _titleService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _titleService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
