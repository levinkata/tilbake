using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class MotorModelsController : Controller
    {
        private readonly IMotorModelService _motorModelService;

        public MotorModelsController(IMotorModelService motorModelService)
        {
            _motorModelService = motorModelService;
        }

        // GET: MotorModels
        public async Task<IActionResult> Index()
        {
            return View(await _motorModelService.GetAllAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorModels(Guid motorMakeId)
        {
            var ViewModels = await _motorModelService.GetByMotorMakeIdAsync(motorMakeId);
            var motormodels = from m in ViewModels
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };
            
            return Json(motormodels);
        }

        // GET: MotorModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _motorModelService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: MotorModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MotorModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MotorModelViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _motorModelService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: MotorModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _motorModelService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: MotorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, MotorModelViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _motorModelService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: MotorModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _motorModelService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: MotorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _motorModelService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
