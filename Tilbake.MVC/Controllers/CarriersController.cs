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
    public class CarriersController : BaseController
    {
        public CarriersController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Carriers
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Carriers.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Carrier>, IEnumerable<CarrierViewModel>>(result);
            return View(model);
        }

        // GET: Carriers/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Carriers.GetById(id);
            var model = _mapper.Map<Carrier, CarrierViewModel>(result);
            return View(model);
        }

        // GET: Carriers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carriers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarrierViewModel model)
        {
            if (ModelState.IsValid)
            {
                var carrier = _mapper.Map<CarrierViewModel, Carrier>(model);
                carrier.Id = Guid.NewGuid();
                carrier.DateAdded = DateTime.Now;

                await _unitOfWork.Carriers.Add(carrier);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Carriers/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Carriers.GetById(id);
            var model = _mapper.Map<Carrier, CarrierViewModel>(result);
            return View(model);
        }

        // POST: Carriers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, CarrierViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var carrier = _mapper.Map<CarrierViewModel, Carrier>(model);
                carrier.DateModified = DateTime.Now;

                await _unitOfWork.Carriers.Update(carrier);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Carriers/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Carriers.GetById(id);
            var model = _mapper.Map<Carrier, CarrierViewModel>(result);
            return View(model);
        }

        // POST: Carriers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Carriers.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
