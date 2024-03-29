﻿using AutoMapper;
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
    public class MaritalStatusController : BaseController
    {
        public MaritalStatusController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: MaritalStatus
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.MaritalStatuses.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<MaritalStatus>, IEnumerable<MaritalStatusViewModel>>(result);
            return View(model);
        }

        // GET: MaritalStatus/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.MaritalStatuses.GetById(id);
            var model = _mapper.Map<MaritalStatus, MaritalStatusViewModel>(result);
            return View(model);
        }

        // GET: MaritalStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MaritalStatusViewModel model)
        {
            if (ModelState.IsValid)
            {
                var maritalStatus = _mapper.Map<MaritalStatusViewModel, MaritalStatus>(model);
                maritalStatus.Id = Guid.NewGuid();
                maritalStatus.DateAdded = DateTime.Now;

                await _unitOfWork.MaritalStatuses.Add(maritalStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MaritalStatus/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.MaritalStatuses.GetById(id);
            var model = _mapper.Map<MaritalStatus, MaritalStatusViewModel>(result);
            return View(model);
        }

        // POST: MaritalStatuses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, MaritalStatusViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var maritalStatus = _mapper.Map<MaritalStatusViewModel, MaritalStatus>(model);
                maritalStatus.DateModified = DateTime.Now;

                await _unitOfWork.MaritalStatuses.Update(maritalStatus);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: MaritalStatuses/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.MaritalStatuses.GetById(id);
            var model = _mapper.Map<MaritalStatus, MaritalStatusViewModel>(result);
            return View(model);
        }

        // POST: MaritalStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.MaritalStatuses.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
