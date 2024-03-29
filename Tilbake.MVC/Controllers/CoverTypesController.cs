﻿using AutoMapper;
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
    public class CoverTypesController : BaseController
    {
        public CoverTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: CoverTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.CoverTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<CoverType>, IEnumerable<CoverTypeViewModel>>(result);
            return View(model);
        }

        // GET: CoverTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.CoverTypes.GetById(id);
            var model = _mapper.Map<CoverType, CoverTypeViewModel>(result);
            return View(model);
        }

        // GET: CoverTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoverTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoverTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var coverType = _mapper.Map<CoverTypeViewModel, CoverType>(model);
                coverType.Id = Guid.NewGuid();
                coverType.DateAdded = DateTime.Now;

                await _unitOfWork.CoverTypes.Add(coverType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CoverTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.CoverTypes.GetById(id);
            var model = _mapper.Map<CoverType, CoverTypeViewModel>(result);
            return View(model);
        }

        // POST: CoverTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, CoverTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var coverType = _mapper.Map<CoverTypeViewModel, CoverType>(model);
                coverType.DateModified = DateTime.Now;

                await _unitOfWork.CoverTypes.Update(coverType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: CoverTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.CoverTypes.GetById(id);
            var model = _mapper.Map<CoverType, CoverTypeViewModel>(result);
            return View(model);
        }

        // POST: CoverTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.CoverTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
