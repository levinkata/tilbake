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
    public class SalesTypesController : BaseController
    {
        public SalesTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: SalesTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.SalesTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<SalesType>, IEnumerable<SalesTypeViewModel>>(result);
            return View(model);
        }

        // GET: SalesTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.SalesTypes.GetById(id);
            var model = _mapper.Map<SalesType, SalesTypeViewModel>(result);
            return View(model);
        }

        // GET: SalesTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SalesTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var salesType = _mapper.Map<SalesTypeViewModel, SalesType>(model);
                salesType.Id = Guid.NewGuid();
                salesType.DateAdded = DateTime.Now;

                await _unitOfWork.SalesTypes.Add(salesType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: SalesTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.SalesTypes.GetById(id);
            var model = _mapper.Map<SalesType, SalesTypeViewModel>(result);
            return View(model);
        }

        // POST: SalesTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, SalesTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var salesType = _mapper.Map<SalesTypeViewModel, SalesType>(model);
                salesType.DateModified = DateTime.Now;

                await _unitOfWork.SalesTypes.Update(salesType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: SalesTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.SalesTypes.GetById(id);
            var model = _mapper.Map<SalesType, SalesTypeViewModel>(result);
            return View(model);
        }

        // POST: SalesTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.SalesTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
