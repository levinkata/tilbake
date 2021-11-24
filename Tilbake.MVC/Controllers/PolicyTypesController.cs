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
    public class PolicyTypesController : BaseController
    {
        public PolicyTypesController(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            UserManager<ApplicationUser> userManager) : base(unitOfWork, mapper, userManager)
        {

        }

        // GET: PolicyTypes
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.PolicyTypes.GetAll(r => r.OrderBy(n => n.Name));
            var model = _mapper.Map<IEnumerable<PolicyType>, IEnumerable<PolicyTypeViewModel>>(result);
            return View(model);
        }

        // GET: PolicyTypes/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var result = await _unitOfWork.PolicyTypes.GetById(id);
            var model = _mapper.Map<PolicyType, PolicyTypeViewModel>(result);
            return View(model);
        }

        // GET: PolicyTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PolicyTypes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PolicyTypeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var policyType = _mapper.Map<PolicyTypeViewModel, PolicyType>(model);
                policyType.Id = Guid.NewGuid();
                policyType.DateAdded = DateTime.Now;

                await _unitOfWork.PolicyTypes.Add(policyType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PolicyTypes/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = await _unitOfWork.PolicyTypes.GetById(id);
            var model = _mapper.Map<PolicyType, PolicyTypeViewModel>(result);
            return View(model);
        }

        // POST: PolicyTypes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid? id, PolicyTypeViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var policyType = _mapper.Map<PolicyTypeViewModel, PolicyType>(model);
                policyType.DateModified = DateTime.Now;

                await _unitOfWork.PolicyTypes.Update(policyType);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: PolicyTypes/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _unitOfWork.PolicyTypes.GetById(id);
            var model = _mapper.Map<PolicyType, PolicyTypeViewModel>(result);
            return View(model);
        }

        // POST: PolicyTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _unitOfWork.PolicyTypes.Delete(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
