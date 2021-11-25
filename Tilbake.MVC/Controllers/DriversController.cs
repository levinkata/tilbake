using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class DriversController : BaseController
    {
        public DriversController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Drivers
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Drivers.GetAll(r => r.OrderBy(n => n.LastName));
            var model = _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverViewModel>>(result);
            return View(model);
        }

        // GET: Drivers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Drivers.GetById(id);
            var model = _mapper.Map<Driver, DriverViewModel>(result);
            return View(model);
        }

        // GET: Drivers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Drivers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverViewModel model)
        {
            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<DriverViewModel, Driver>(model);
                driver.Id = Guid.NewGuid();
                driver.DateAdded = DateTime.Now;

                await _unitOfWork.Drivers.Add(driver);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Drivers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Drivers.GetById(id);
            var model = _mapper.Map<Driver, DriverViewModel>(result);
            return View(model);
        }

        // POST: Drivers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, DriverViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var driver = _mapper.Map<DriverViewModel, Driver>(model);
                driver.DateModified = DateTime.Now;

                await _unitOfWork.Drivers.Update(driver);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Drivers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Drivers.GetById(id);
            var model = _mapper.Map<Driver, DriverViewModel>(result);
            return View(model);
        }

        // POST: Drivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Drivers.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
