using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tilbake.Core;
using Tilbake.Core.Models;
using Tilbake.MVC.Areas.Identity;
using Tilbake.MVC.Models;

namespace Tilbake.MVC.Controllers
{
    [Authorize]
    public class TravelsController : BaseController
    {
        public TravelsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Travels
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Travels.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Travel>, IEnumerable<TravelViewModel>>(result);
            return View(model);
        }

        // GET: Travels/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var result = await _unitOfWork.Travels.GetById(id);
            var model = _mapper.Map<Travel, TravelViewModel>(result);
            return View(model);
        }

        // GET: Travels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Travels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TravelViewModel model)
        {
            if (ModelState.IsValid)
            {
                var travel = _mapper.Map<TravelViewModel, Travel>(model);
                travel.Id = Guid.NewGuid();
                travel.DateAdded = DateTime.Now;

                await _unitOfWork.Travels.Add(travel);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Travels/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Travels.GetById(id);
            var model = _mapper.Map<Travel, TravelViewModel>(result);
            return View(model);
        }

        // POST: Travels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, TravelViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var travel = _mapper.Map<TravelViewModel, Travel>(model);
                travel.DateModified = DateTime.Now;

                await _unitOfWork.Travels.Update(travel);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Travels.GetById(id);
            var model = _mapper.Map<Travel, TravelViewModel>(result);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Travels.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
