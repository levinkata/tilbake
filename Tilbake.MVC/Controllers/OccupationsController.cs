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
    public class OccupationsController : BaseController
    {
        public OccupationsController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: Occupations
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.Occupations.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<Occupation>, IEnumerable<OccupationViewModel>>(result);
            return View(model);
        }

        // GET: Occupations/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.Occupations.GetById(id);

            var model = _mapper.Map<Occupation, OccupationViewModel>(result);
            return View(model);
        }

        // GET: Occupations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Occupations/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OccupationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var occupation = _mapper.Map<OccupationViewModel, Occupation>(model);
                occupation.Id = Guid.NewGuid();
                occupation.DateAdded = DateTime.Now;

                await _unitOfWork.Occupations.Add(occupation);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Occupations/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.Occupations.GetById(id);

            var model = _mapper.Map<Occupation, OccupationViewModel>(result);
            return View(model);
        }

        // POST: Occupations/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, OccupationViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var occupation = _mapper.Map<OccupationViewModel, Occupation>(model);
                occupation.DateModified = DateTime.Now;

                await _unitOfWork.Occupations.Update(occupation);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Occupations/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.Occupations.GetById(id);

            var model = _mapper.Map<Occupation, OccupationViewModel>(result);
            return View(model);
        }

        // POST: Occupations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.Occupations.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
