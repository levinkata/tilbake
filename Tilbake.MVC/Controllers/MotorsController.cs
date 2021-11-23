using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Application.Interfaces;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class MotorsController : Controller
    {
        private readonly IMotorService _motorService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IDriverTypeService _driverTypeService;
        private readonly IMotorMakeService _motorMakeService;
        private readonly IMotorModelService _motorModelService;

        public MotorsController(IMotorService motorService,
                                IBodyTypeService bodyTypeService,
                                IDriverTypeService driverTypeService,
                                IMotorMakeService motorMakeService,
                                IMotorModelService motorModelService)
        {
            _motorService = motorService;
            _bodyTypeService = bodyTypeService;
            _driverTypeService = driverTypeService;
            _motorMakeService = motorMakeService;
            _motorModelService = motorModelService;
        }

        // GET: Motors
        public async Task<IActionResult> Index()
        {

            return View(await _motorService.GetAllAsync());
        }

        // GET: Motors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _motorService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // GET: Motors/Create
        public async Task<IActionResult> Create(Guid portfolioClientId)
        {
            var bodyTypes = await _bodyTypeService.GetAllAsync();
            var driverTypes = await _driverTypeService.GetAllAsync();
            var motorMakes = await _motorMakeService.GetAllAsync();
            var motorMakeId = motorMakes.FirstOrDefault().Id;
            var motorModels = await _motorModelService.GetByMotorMakeIdAsync(motorMakeId);
            
            MotorViewModel ViewModel = new MotorViewModel()
            {
                PortfolioClientId = portfolioClientId,
                BodyTypeList = new SelectList(bodyTypes, "Id", "Name"),
                DriverTypeList = new SelectList(driverTypes, "Id", "Name"),
                MotorMakeList = new SelectList(motorMakes, "Id", "Name"),
                MotorModelList = new SelectList(motorModels, "Id", "Name"),
            };
            return await Task.Run(() => View(ViewModel));
        }

        // POST: Motors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MotorViewModel ViewModel)
        {
            if (ModelState.IsValid)
            {
                _motorService.AddAsync(ViewModel);
                return RedirectToAction(nameof(Index), "PortfolioClient", new { ViewModel.PortfolioClientId });
            }
            return View(ViewModel);
        }

        // GET: Motors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _motorService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }
            return View(ViewModel);
        }

        // POST: Motors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid? id, MotorViewModel ViewModel)
        {
            if (id != ViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _motorService.UpdateAsync(ViewModel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ViewModel);
        }

        // GET: Motors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ViewModel = await _motorService.GetByIdAsync((Guid)id);
            if (ViewModel == null)
            {
                return NotFound();
            }

            return View(ViewModel);
        }

        // POST: Motors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _motorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
