using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

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
            var ViewModels = await _titleService.GetAllAsync();
            var titles = from m in ViewModels
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

            var ViewModel = await _titleService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Titles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TitleViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _titleService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _titleService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: Titles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, TitleViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _titleService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _titleService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
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
