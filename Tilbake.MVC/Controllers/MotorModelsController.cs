using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.Application.Resources;

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
            var resources = await _motorModelService.GetByMotorMakeIdAsync(motorMakeId);
            var motormodels = from m in resources
                              select new
                              {
                                  m.Id,
                                  m.Name
                              };
            
            return await Task.Run(() => Json(motormodels)).ConfigureAwait(true);
        }

        // GET: MotorModels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _motorModelService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
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
        public async Task<IActionResult> Create(MotorModelSaveResource resource)
        {
            if (ModelState.IsValid)
            {
                await _motorModelService.AddAsync(resource);
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: MotorModels/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _motorModelService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }
            return View(resource);
        }

        // POST: MotorModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, MotorModelResource resource)
        {
            if (id != resource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _motorModelService.UpdateAsync(resource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(resource);
        }

        // GET: MotorModels/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resource = await _motorModelService.GetByIdAsync((Guid)id);
            if (resource == null)
            {
                return NotFound();
            }

            return View(resource);
        }

        // POST: MotorModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _motorModelService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
