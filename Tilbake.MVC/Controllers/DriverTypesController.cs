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
    public class DriverTypesController : BaseController
    {
        public DriverTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: DriverTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.DriverTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<DriverType>, IEnumerable<DriverTypeViewModel>>(result);
            return View(model);
        }

        // GET: DriverTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.DriverTypes.GetById(id);
            var model = _mapper.Map<DriverType, DriverTypeViewModel>(result);
            return View(model);
        }

        // GET: DriverTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DriverTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DriverTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var driverType = _mapper.Map<DriverTypeViewModel, DriverType>(model);
                driverType.Id = Guid.NewGuid();
                driverType.DateAdded = DateTime.Now;

                await _unitOfWork.DriverTypes.Add(driverType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DriverTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.DriverTypes.GetById(id);
            var model = _mapper.Map<DriverType, DriverTypeViewModel>(result);
            return View(model);
        }

        // POST: DriverTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, DriverTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var driverType = _mapper.Map<DriverTypeViewModel, DriverType>(model);
                driverType.DateModified = DateTime.Now;

                await _unitOfWork.DriverTypes.Update(driverType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: DriverTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.DriverTypes.GetById(id);
            var model = _mapper.Map<DriverType, DriverTypeViewModel>(result);
            return View(model);
        }

        // POST: DriverTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.DriverTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
